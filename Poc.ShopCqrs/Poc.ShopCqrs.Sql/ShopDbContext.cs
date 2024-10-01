using Microsoft.EntityFrameworkCore;
using Poc.ShopCqrs.Domain.Entity;
using Poc.ShopCqrs.Sql.EntityConfiguration;

namespace Poc.ShopCqrs.Sql
{
    public class ShopDbContext(DbContextOptions<ShopDbContext> options) : DbContext(options)
    {
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
