﻿using Microsoft.EntityFrameworkCore;
using Poc.ShopCqrs.Domain.Entity;
using Poc.ShopCqrs.Sql.EntityConfiguration;

namespace Poc.ShopCqrs.Sql
{
    public class ShopDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
            => Database.EnsureCreated();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
