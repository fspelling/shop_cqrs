using MediatR;

namespace Poc.ShopCqrs.Domain.Messaging
{
    public interface IEventBus
    {
        Task<TResponse> Send<TResponse>(IRequest<TResponse> request);
        Task Publish<TEvent>(TEvent @event) where TEvent : Event;
    }
}
