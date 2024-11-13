using MediatR;

namespace Poc.ShopCqrs.Domain.Core.Messaging
{
    public abstract class Event : Message, INotification
    {
        public TimeSpan TimeStamp { get; set; } = TimeSpan.Zero;
    }
}
