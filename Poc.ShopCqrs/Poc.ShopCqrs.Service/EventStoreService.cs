using Poc.ShopCqrs.Domain.Core.Events;
using Poc.ShopCqrs.Domain.Entity.Base;
using Poc.ShopCqrs.Domain.Enums;
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

        // TODO
        public async Task RestaureEntity<TEntity>(Guid eventStoreId, Guid aggregateId) where TEntity : EntityBase
        {
            var historyList = new List<TEntity>();

            var eventsHistory = await _eventStoreRepository.All(aggregateId);
            var eventsHistoryUpdate = eventsHistory.First(eh => eh.Id == eventStoreId);
            var historyData = JsonSerializer.Deserialize<TEntity>(eventsHistoryUpdate.Data!)!;

            if (typeof(TEntity).Name == EntityCacheEnum.Consumer.ToString())
            {
                var nameProperty = typeof(TEntity).GetProperty("Name");
                var emailProperty = typeof(TEntity).GetProperty("Email");

                var customerCache = new Domain.ModelCache.Customer
                {
                    ID = historyData.ID,
                    Name = nameProperty!.GetValue(historyData)?.ToString()!,
                    Email = emailProperty!.GetValue(historyData)?.ToString()!
                };

                await _customerCache.SetCache(historyData.ID.ToString(), customerCache);
            }
        }
    }
}
