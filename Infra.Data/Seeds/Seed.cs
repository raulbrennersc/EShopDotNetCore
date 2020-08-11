using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Domain.Entities;
using Infra.Data.Context;

namespace Infra.Data.Seeds
{
    public class Seed
    {
        public static void SeedProducts(EShopContext context)
        {
            if (!context.Customers.Any())
            {
                var productData = System.IO.File.ReadAllText("../Infra.Data/Seeds/ProductSeed.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productData);
                foreach (var product in products)
                {
                    context.Products.Add(product);
                }
                context.SaveChanges();
            }
        }

        public static void SeedCustomers(EShopContext context)
        {
            if (!context.Customers.Any())
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash("password", out passwordHash, out passwordSalt);
                var customer = new Customer
                {
                    Cpf = "00000000000",
                    BirthDate = new DateTime(2000, 01, 01),
                    Email = "customer@email.com",
                    FirstName = "Doom",
                    LastName = "Guy",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                };
                context.Customers.Add(customer);
                context.SaveChanges();
            }
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}