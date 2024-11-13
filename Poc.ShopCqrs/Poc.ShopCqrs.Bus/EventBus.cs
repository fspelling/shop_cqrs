using MediatR;
using Poc.ShopCqrs.Domain.Core.Messaging;
using Poc.ShopCqrs.Domain.Interfaces.EventBus;

namespace Poc.ShopCqrs.Bus
{
    public class EventBus(IMediator mediator) : IEventBus
    {
        private readonly IMediator _mediator = mediator;

        public async Task<TResponse> SendQuery<TResponse>(IRequest<TResponse> query)
            => await _mediator.Send(query);

        public async Task SendCommand(IRequest command)
            => await _mediator.Send(command);

        public async Task Publish<TEvent>(TEvent @event) where TEvent : Event
        {
            //_eventStore.Save(@event);
            await _mediator.Publish(@event!);
        }
    }
}
