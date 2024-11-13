using MediatR;

namespace Poc.ShopCqrs.Domain.Core.Messaging
{
    public abstract class Command : Message, IRequest
    {
        public required TimeSpan TimeStamp { get; set; } = TimeSpan.Zero;
    }
}
