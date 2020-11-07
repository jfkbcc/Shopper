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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ShoppingCartItem>()
                .HasIndex(u => new { u.ID, u.ProductID })
                .IsUnique();
        }
    }
}
