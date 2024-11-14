using MediatR;

namespace Poc.ShopCqrs.Domain.Core.Messaging
{
    public abstract class Command : Message, IRequest
    {
        public required DateTime TimeStamp { get; set; } = DateTime.Now;
    }
}
