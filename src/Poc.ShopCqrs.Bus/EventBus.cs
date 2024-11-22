using MediatR;
using Poc.ShopCqrs.Domain.Core.Entity;
using Poc.ShopCqrs.Domain.Core.Events;
using Poc.ShopCqrs.Domain.Core.Messaging;
using Poc.ShopCqrs.Domain.Interfaces.EventBus;

namespace Poc.ShopCqrs.Bus
{
    public class EventBus(IMediator mediator, IEventStore eventStore) : IEventBus
    {
        private readonly IMediator _mediator = mediator;
        private readonly IEventStore _eventStore = eventStore;

        public async Task<TResponse> SendQuery<TResponse>(IRequest<TResponse> query)
            => await _mediator.Send(query);

        public async Task SendCommand(IRequest command)
            => await _mediator.Send(command);

        public async Task Publish<TEvent, TEntity>(TEvent @event, TEntity entity, string entityName) 
            where TEvent : Event where TEntity : EntityBase
        {
            _eventStore.Save(@event, entity, entityName);
            await _mediator.Publish(@event!);
        }

        public async Task Publish<TEvent>(TEvent @event) where TEvent : Event
            => await _mediator.Publish(@event!);
    }
}
