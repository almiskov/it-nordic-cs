using Lesson_34_Classwork.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_34_Classwork.Data
{
    public class OnlineStoreContext : DbContext
    {
        private string _connectionString;

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public OnlineStoreContext()
        {
            _connectionString =
                @"Data Source=localhost\SQLEXPRESS;" +
                @"Initial Catalog=OnlineStoreEF;" +
                "Integrated Security=true";
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Customer>()
                    .HasAlternateKey(c => c.Name)
                    .HasName("UQ_Customers_Name");

            modelBuilder
                .Entity<OrderItem>()
                    .HasKey("OrderID", "ProductId")
                    .HasName("PK_OrderItems");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
