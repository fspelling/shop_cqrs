using Poc.ShopCqrs.Domain.Core.Events;
using Poc.ShopCqrs.Domain.Entity.Base;

namespace Poc.ShopCqrs.Domain.Interfaces.Service
{
    public interface IEventStoreService
    {
        Task<List<StoredEvent>> ObterHistoryPorAggregateId(Guid aggregateId);
        Task RestaureEntity<TEntity>(Guid eventStoreId, Guid aggregateId) where TEntity : EntityBase;
    }
}
