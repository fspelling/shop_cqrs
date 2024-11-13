﻿using Microsoft.EntityFrameworkCore;
using Poc.ShopCqrs.Domain.Entity;
using Poc.ShopCqrs.Sql.Mappings;

namespace Poc.ShopCqrs.Sql.Context
{
    public class ShopDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
            => Database.EnsureCreated();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}