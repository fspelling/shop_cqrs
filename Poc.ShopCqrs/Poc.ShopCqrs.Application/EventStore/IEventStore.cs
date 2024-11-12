using Poc.ShopCqrs.Domain.Messaging;

namespace Poc.ShopCqrs.Application.EventStore
{
    public interface IEventStore
    {
        Task Save<TEvent>(TEvent @event) where TEvent : Event;
        Task<List<Event>> GetEventsByAggregateId(string aggregateId);
    }
}
