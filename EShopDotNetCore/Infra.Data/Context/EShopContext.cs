using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Data.Context
{
    public class EShopContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<CartItem> CartItems{ get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryProduct> CategoryProducts { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderCoupon> OrderCoupons { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }

        public EShopContext(DbContextOptions<EShopContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("eshop");
        }
    }
}
