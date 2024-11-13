using Poc.ShopCqrs.Domain.Core.Messaging;

namespace Poc.ShopCqrs.Domain.Core.Events
{
    public interface IEventStore
    {
        void Save<T>(T @event) where T : Event;
        IEnumerable<Event> GetEvents(Guid aggregateId);
    }
}
