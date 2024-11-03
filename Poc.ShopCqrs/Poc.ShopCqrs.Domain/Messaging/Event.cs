using MediatR;

namespace Poc.ShopCqrs.Domain.Messaging
{
    public abstract class Event : INotification
    {
        public TimeSpan TimeStamp { get; set; } = TimeSpan.Zero;
    }
}
