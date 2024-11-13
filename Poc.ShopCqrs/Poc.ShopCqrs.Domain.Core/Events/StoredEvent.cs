using Poc.ShopCqrs.Domain.Core.Messaging;

namespace Poc.ShopCqrs.Domain.Core.Events
{
    public class StoredEvent : Event
    {
        public Guid Id { get; private set; }
        public string? Data { get; private set; }

        protected StoredEvent() { }

        public StoredEvent(Event theEvent, string data)
        {
            Id = Guid.NewGuid();
            Data = data;
            AggregateId = theEvent.AggregateId;
            MessageType = theEvent.MessageType;
        }
    }
}
