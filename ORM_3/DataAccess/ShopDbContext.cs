using Microsoft.EntityFrameworkCore;
using ORM_3.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ORM_3.DataAcces
{
    public class ShopDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MADI;Database=ShopDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderProduct>()
                .HasKey(op => new { op.OrderId, op.ProductId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
