using Poc.ShopCqrs.Domain.Core.Entity;
using Poc.ShopCqrs.Domain.Core.Events;
using Poc.ShopCqrs.Domain.Enums;
using Poc.ShopCqrs.Domain.Exceptions;
using Poc.ShopCqrs.Domain.Interfaces.Cache;
using Poc.ShopCqrs.Domain.Interfaces.Repository.EventSourcing;
using Poc.ShopCqrs.Domain.Interfaces.Service;
using System.Text.Json;

namespace Poc.ShopCqrs.Service
{
    public class EventStoreService(IEventStoreRepository eventStoreRepository, ICustomerCache customerCache) : IEventStoreService
    {
        private readonly IEventStoreRepository _eventStoreRepository = eventStoreRepository;
        private readonly ICustomerCache _customerCache = customerCache;

        public async Task<List<StoredEvent>> ObterHistoryPorAggregateId(Guid aggregateId)
            => await _eventStoreRepository.All(aggregateId);

        public async Task RestaureEntity<TEntity>(string entityName, Guid aggregateId) where TEntity : EntityBase
        {
            var events = await _eventStoreRepository.All(aggregateId);

            if (!events.Any())
                throw new EventStoreException("Nenhum evento encontrado para o AggregateId especificado.");

            var orderedEvents = events.OrderBy(e => e.TimeStamp);

            TEntity entity = Activator.CreateInstance<TEntity>();

            foreach (var storedEvent in orderedEvents)
            {
                var eventDataEntity = JsonSerializer.Deserialize<TEntity>(storedEvent.DataEntity!);

                if (eventDataEntity == null)
                    throw new EventStoreException("Falha na desserialização da entidade do evento.");

                entity.ApplyEvent(eventDataEntity);
            }

            if (typeof(TEntity).Name == EntityCacheEnum.Customer.ToString())
            {
                var customerCache = new Domain.ModelCache.Customer
                {
                    ID = aggregateId,
                    Name = entity.GetType().GetProperty("Name")?.GetValue(entity)?.ToString()!,
                    Email = entity.GetType().GetProperty("Email")?.GetValue(entity)?.ToString()!
                };

                await _customerCache.SetCache(aggregateId.ToString(), customerCache);
            }
        }
    }
}
