using MediatR;

namespace Poc.ShopCqrs.Domain.Messaging
{
    public class EventBus(IMediator mediator) : IEventBus
    {
        private readonly IMediator _mediator = mediator;

        public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
            => await _mediator.Send(request);

        public async Task Publish<TEvent>(TEvent @event) where TEvent : Event
            => await _mediator.Publish(@event!);
    }
}
