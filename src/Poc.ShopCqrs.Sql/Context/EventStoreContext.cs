using Microsoft.EntityFrameworkCore;
using Poc.ShopCqrs.Domain.Core.Events;
using Poc.ShopCqrs.Data.Mappings;
using Poc.ShopCqrs.Domain.Core.Messaging;

namespace Poc.ShopCqrs.Data.Context
{
    public class EventStoreContext : DbContext
    {
        public DbSet<StoredEvent> StoredEvent { get; set; }

        public EventStoreContext(DbContextOptions<EventStoreContext> options) : base(options)
            => Database.EnsureCreated();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Event>();

            modelBuilder.ApplyConfiguration(new StoredEventMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
