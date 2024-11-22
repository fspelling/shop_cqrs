using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Poc.ShopCqrs.Domain.Core.Events;

namespace Poc.ShopCqrs.Data.Mappings
{
    public class StoredEventMap : IEntityTypeConfiguration<StoredEvent>
    {
        public void Configure(EntityTypeBuilder<StoredEvent> builder)
            => builder.Property(c => c.MessageType).HasColumnName("Action").HasColumnType("varchar(100)");
    }
}
