using Poc.ShopCqrs.Domain.Core.Events;

namespace Poc.ShopCqrs.Data.Repository.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent @event);
        Task<IList<StoredEvent>> All(Guid aggregateId);
    }
}
