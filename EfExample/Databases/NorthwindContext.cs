using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace EfExample
{
    public class NorthwindContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        string userName = "TestUser";
        string userPass = "Test";
        string server = "localhost";
        string database = "northwind";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseMySql("server=" + server + ";" +
            "database=" + database + ";" +
            "uid=" + userName + ";" +
            "pwd=" + userPass + ";" +
            "SslMode=none");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().Property(x => x.Id).HasColumnName("CategoryId");
            modelBuilder.Entity<Category>().Property(x => x.Name).HasColumnName("CategoryName");
            modelBuilder.Entity<Category>().Property(x => x.Description).HasColumnName("Description");

            modelBuilder.Entity<Product>().Property(x => x.Id).HasColumnName("ProductId");
            modelBuilder.Entity<Product>().Property(x => x.Name).HasColumnName("ProductName");
            modelBuilder.Entity<Product>().Property(x => x.QuantityPerUnit).HasColumnName("QuantityUnit");
            modelBuilder.Entity<Product>().Property(x => x.UnitPrice).HasColumnName("UnitPrice");
            modelBuilder.Entity<Product>().Property(x => x.UnitsInStock).HasColumnName("UnitsInStock");

            modelBuilder.Entity<Order>().Property(x => x.Id).HasColumnName("OrderId");
            modelBuilder.Entity<Order>().Property(x => x.Date).HasColumnName("OrderDate");
            modelBuilder.Entity<Order>().Property(x => x.Required).HasColumnName("RequiredDate");
            modelBuilder.Entity<Order>().Property(x => x.ShipName).HasColumnName("ShipName");
            modelBuilder.Entity<Order>().Property(x => x.ShipCity).HasColumnName("ShipCity");

            modelBuilder.Entity<OrderDetails>().Property(x => x.OrderId).HasColumnName("OrderId");
            modelBuilder.Entity<OrderDetails>().Property(x => x.ProductId).HasColumnName("ProductId");
            modelBuilder.Entity<OrderDetails>().Property(x => x.UnitPrice).HasColumnName("UnitPrice");
            modelBuilder.Entity<OrderDetails>().Property(x => x.Quantity).HasColumnName("Quantity");
            modelBuilder.Entity<OrderDetails>().Property(x => x.Discount).HasColumnName("Discount");

            modelBuilder.Entity<OrderDetails>().HasKey(table => new { table.OrderId, table.ProductId });
        }
    }
}
