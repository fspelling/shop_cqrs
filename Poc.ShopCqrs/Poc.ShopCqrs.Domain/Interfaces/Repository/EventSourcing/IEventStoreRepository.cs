using Poc.ShopCqrs.Domain.Core.Events;

namespace Poc.ShopCqrs.Domain.Interfaces.Repository.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent @event);
        Task<List<StoredEvent>> All(string aggregateId);
    }
}
