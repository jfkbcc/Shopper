using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShoppingLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingLibrary
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Address> AddressBook { get; set; }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<ShoppingCart> ShoppingCart { get; set; }

        public virtual DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ShoppingCart>()
                .HasIndex(u => new { u.ID, u.CustomerID })
                .IsUnique();

            builder.Entity<ShoppingCartItem>()
                .HasIndex(u => new { u.ID, u.ProductID })
                .IsUnique();

            builder.Entity<Customer>()
                .HasIndex(u => u.Email)
                .IsUnique();

            #region AdminLoginSeeding
            builder.Entity<Customer>().HasData(new Customer
            {
                ID = 1,
                Name = "Administrator",
                Email = "admin",
                Gender = "M",
                IsAdmin = true
            });
			#endregion

			#region ProductSeeding
			builder.Entity<Product>().HasData(new Product
            {
                ID = 1,
                Name = "Apple iPhone XR (Red, 128 GB)",
                Description = "128 GB ROM | 15.49 cm (6.1 inch) Display 12MP Rear Camera | 7MP Front Camera A12 Bionic Chip Processor",
                Price = 650.00m,
                Image = "https://i.imgur.com/KFojDGa.jpg"
            });

            builder.Entity<Product>().HasData(new Product
            {
                ID = 2,
                Name = "Apple iPhone XR (Red, 256 GB)",
                Description = "256 GB ROM | 15.49 cm (6.1 inch) Display 12MP Rear Camera | 7MP Front Camera A12 Bionic Chip Processor",
                Price = 750.00m,
                Image = "https://i.imgur.com/KFojDGa.jpg"
            });

            builder.Entity<Product>().HasData(new Product
            {
                ID = 3,
                Name = "Apple iPhone XR (Red, 512 GB)",
                Description = "512 GB ROM | 15.49 cm (6.1 inch) Display 12MP Rear Camera | 7MP Front Camera A12 Bionic Chip Processor",
                Price = 850.00m,
                Image = "https://i.imgur.com/KFojDGa.jpg"
            });
			#endregion
		}
	}
}
