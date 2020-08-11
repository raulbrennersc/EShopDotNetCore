using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Infra.Data.Context;
using Infra.Data.Repository;
using Infra.Data.UnitOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Services.Services;

namespace Application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EShopContext>(x => x.UseLazyLoadingProxies().UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };
                });

            //Services
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICartItemService, CartItemService>();
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<IService<Category>, BaseService<Category>>();
            services.AddScoped<IService<CategoryProduct>, BaseService<CategoryProduct>>();
            services.AddScoped<IService<Coupon>, BaseService<Coupon>>();
            services.AddScoped<IService<CreditCard>, BaseService<CreditCard>>();
            services.AddScoped<IService<Favorite>, BaseService<Favorite>>();
            services.AddScoped<IService<Order>, BaseService<Order>>();
            services.AddScoped<IService<OrderCoupon>, BaseService<OrderCoupon>>();
            services.AddScoped<IService<OrderProduct>, BaseService<OrderProduct>>();
            services.AddScoped<IService<ProductDetail>, BaseService<ProductDetail>>();
            services.AddScoped<IService<Review>, BaseService<Review>>();
            services.AddScoped<IService<Customer>, BaseService<Customer>>();

            //Repositories
            services.AddScoped<IRepository<Address>, BaseRepository<Address>>();
            services.AddScoped<IRepository<CartItem>, BaseRepository<CartItem>>();
            services.AddScoped<IRepository<Category>, BaseRepository<Category>>();
            services.AddScoped<IRepository<CategoryProduct>, BaseRepository<CategoryProduct>>();
            services.AddScoped<IRepository<Coupon>, BaseRepository<Coupon>>();
            services.AddScoped<IRepository<CreditCard>, BaseRepository<CreditCard>>();
            services.AddScoped<IRepository<Favorite>, BaseRepository<Favorite>>();
            services.AddScoped<IRepository<Order>, BaseRepository<Order>>();
            services.AddScoped<IRepository<OrderCoupon>, BaseRepository<OrderCoupon>>();
            services.AddScoped<IRepository<OrderProduct>, BaseRepository<OrderProduct>>();
            services.AddScoped<IRepository<Product>, BaseRepository<Product>>();
            services.AddScoped<IRepository<ProductDetail>, BaseRepository<ProductDetail>>();
            services.AddScoped<IRepository<Review>, BaseRepository<Review>>();
            services.AddScoped<IRepository<Customer>, BaseRepository<Customer>>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseAuthentication();

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
