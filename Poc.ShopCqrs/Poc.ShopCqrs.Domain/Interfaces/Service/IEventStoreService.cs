using Poc.ShopCqrs.Domain.Core.Entity;
using Poc.ShopCqrs.Domain.Core.Events;

namespace Poc.ShopCqrs.Domain.Interfaces.Service
{
    public interface IEventStoreService
    {
        Task<List<StoredEvent>> ObterHistoryPorAggregateId(Guid aggregateId);
        Task RestaureEntity<TEntity>(string entityName, Guid aggregateId) where TEntity : EntityBase;
    }
}
