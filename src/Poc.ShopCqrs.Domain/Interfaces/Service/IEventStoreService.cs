using Poc.ShopCqrs.Domain.Core.Entity;
using Poc.ShopCqrs.Domain.Core.Events;

namespace Poc.ShopCqrs.Domain.Interfaces.Service
{
    public interface IEventStoreService
    {
        Task<List<StoredEvent>> ObterHistoryPorAggregateId(string aggregateId);
        Task RestaureEntity(string aggregateId);
    }
}
