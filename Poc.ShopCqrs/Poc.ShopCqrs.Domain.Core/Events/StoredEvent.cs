using Poc.ShopCqrs.Domain.Core.Messaging;

namespace Poc.ShopCqrs.Domain.Core.Events
{
    public class StoredEvent
    {
        public Guid Id { get; private set; }
        public string? Data { get; private set; }
        public Guid AggregateId { get; private set; }
        public string? MessageType { get; private set; }
        public TimeSpan TimeStamp { get; private set; }

        // EF Constructor
        protected StoredEvent() { }

        public StoredEvent(Event @event, string data)
        {
            Id = Guid.NewGuid();
            Data = data;
            AggregateId = @event.AggregateId;
            MessageType = @event.MessageType;
            TimeStamp = @event.TimeStamp;
        }
    }
}
