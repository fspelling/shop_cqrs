using Microsoft.EntityFrameworkCore;
using Poc.ShopCqrs.Domain.Core.Events;
using Poc.ShopCqrs.Sql.Context;

namespace Poc.ShopCqrs.Sql.Repository.EventSourcing
{
    public class EventStoreRepository(EventStoreContext eventStoreContext) : IEventStoreRepository
    {
        private readonly EventStoreContext _eventStoreContext = eventStoreContext;

        public async Task<IList<StoredEvent>> All(Guid aggregateId)
            => await _eventStoreContext.StoredEvent.Where(se => se.AggregateId == aggregateId).Select(s => s).ToListAsync();

        public void Store(StoredEvent @event)
        {
            _eventStoreContext.StoredEvent.Add(@event);
            _eventStoreContext.SaveChanges();
        }

        public void Dispose()
            => _eventStoreContext.Dispose();
    }
}
