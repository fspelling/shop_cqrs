using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Poc.ShopCqrs.Domain.Entity;

namespace Poc.ShopCqrs.Sql.Mappings
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(p => p.ID);
            builder.Property(p => p.Email).IsRequired().HasMaxLength(50);
        }
    }
}
