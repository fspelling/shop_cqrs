using MediatR;

namespace Poc.ShopCqrs.Domain.Messaging
{
    public abstract class Query<TResponse> : Message, IRequest<TResponse>
    {
        public required TimeSpan TimeStamp { get; set; } = TimeSpan.Zero;
    }
}
