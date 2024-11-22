using Microsoft.EntityFrameworkCore;
using Poc.ShopCqrs.Domain.Entity;
using Poc.ShopCqrs.Data.Mappings;
using Poc.ShopCqrs.Domain.Core.Messaging;

namespace Poc.ShopCqrs.Data.Context
{
    public class ShopDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
            => Database.EnsureCreated();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Event>();

            modelBuilder.ApplyConfiguration(new CustomerMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
