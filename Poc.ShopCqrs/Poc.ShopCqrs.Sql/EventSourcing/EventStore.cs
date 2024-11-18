using Newtonsoft.Json;
using Poc.ShopCqrs.Domain.Core.Entity;
using Poc.ShopCqrs.Domain.Core.Events;
using Poc.ShopCqrs.Domain.Core.Messaging;
using Poc.ShopCqrs.Domain.Interfaces.Repository.EventSourcing;

namespace Poc.ShopCqrs.Data.EventSourcing
{
    public class EventStore(IEventStoreRepository eventStoreRepository) : IEventStore
    {
        private readonly IEventStoreRepository _eventStoreRepository = eventStoreRepository;

        public void Save<TEvent, TEntity>(TEvent @event, TEntity entity)
            where TEvent : Event where TEntity : EntityBase
        {
            var dataEvent = JsonConvert.SerializeObject(@event);
            var dataEntity = JsonConvert.SerializeObject(entity);

            var storedEvent = new StoredEvent(@event, dataEvent, dataEntity);
            _eventStoreRepository.Store(storedEvent);
        }
    }
}
