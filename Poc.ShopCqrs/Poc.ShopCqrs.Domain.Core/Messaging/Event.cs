using MediatR;

namespace Poc.ShopCqrs.Domain.Core.Messaging
{
    public abstract class Event : Message, INotification
    {
        public DateTime TimeStamp { get; set; } = DateTime.Now;
    }
}
