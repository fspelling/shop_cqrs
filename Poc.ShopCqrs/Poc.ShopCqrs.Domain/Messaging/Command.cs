using MediatR;

namespace Poc.ShopCqrs.Domain.Messaging
{
    public abstract class Command : Message, IRequest
    {
        public required TimeSpan TimeStamp { get; set; } = TimeSpan.Zero;
    }
}
