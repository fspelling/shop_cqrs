using MediatR;

namespace Poc.ShopCqrs.Domain.Messaging
{
    public abstract class Command<TResponse> : IRequest<TResponse>
    {
        public required TimeSpan TimeStamp { get; set; } = TimeSpan.Zero;
    }
}
