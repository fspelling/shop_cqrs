using MediatR;
using Poc.ShopCqrs.Domain.Core.Entity;
using Poc.ShopCqrs.Domain.Core.Messaging;

namespace Poc.ShopCqrs.Domain.Interfaces.EventBus
{
    public interface IEventBus
    {
        Task<TResponse> SendQuery<TResponse>(IRequest<TResponse> query);
        Task SendCommand(IRequest command);
        Task Publish<TEvent, TEntity>(TEvent @event, TEntity entity, string entityName) where TEvent : Event where TEntity : EntityBase;
        Task Publish<TEvent>(TEvent @event) where TEvent : Event;
    }
}
