using Newtonsoft.Json;
using Poc.ShopCqrs.Domain.Core.Events;
using Poc.ShopCqrs.Domain.Core.Messaging;
using Poc.ShopCqrs.Sql.Repository.EventSourcing;

namespace Poc.ShopCqrs.Sql.EventSourcing
{
    public class EventStore(IEventStoreRepository eventStoreRepository) : IEventStore
    {
        private readonly IEventStoreRepository _eventStoreRepository = eventStoreRepository;

        public IEnumerable<Event> GetEvents(Guid aggregateId)
        {
            throw new NotImplementedException();
        }

        public void Save<T>(T @event) where T : Event
        {
            var data = JsonConvert.SerializeObject(@event);
            var storedEvent = new StoredEvent(@event, data);

            _eventStoreRepository.Store(storedEvent);
        }
    }
}
