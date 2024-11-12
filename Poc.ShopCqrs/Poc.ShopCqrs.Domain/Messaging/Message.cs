namespace Poc.ShopCqrs.Domain.Messaging
{
    public abstract class Message
    {
        public string? MessageType { get; protected set; }
        public Guid AggregateId { get; protected set; }
    }
}
