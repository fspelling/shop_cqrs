using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Poc.ShopCqrs.Domain.Entity;

namespace Poc.ShopCqrs.Sql.EntityConfiguration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(p => p.ID);
            builder.Property(p => p.Email).IsRequired().HasMaxLength(50);
        }
    }
}
