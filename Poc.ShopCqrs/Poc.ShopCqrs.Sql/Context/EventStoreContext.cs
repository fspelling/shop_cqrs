﻿using Microsoft.EntityFrameworkCore;
using Poc.ShopCqrs.Domain.Core.Events;
using Poc.ShopCqrs.Data.Mappings;

namespace Poc.ShopCqrs.Data.Context
{
    public class EventStoreContext(DbContextOptions<EventStoreContext> options) : DbContext(options)
    {
        public DbSet<StoredEvent> StoredEvent { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StoredEventMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
