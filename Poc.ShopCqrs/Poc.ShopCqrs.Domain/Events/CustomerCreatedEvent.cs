using Poc.ShopCqrs.Domain.Core.Messaging;

namespace Poc.ShopCqrs.Domain.Events
{
    public class CustomerCreatedEvent : Event
    {
        public DateTime DataCriacao { get; private set; } = DateTime.Now;
        public Guid CustomerID { get; private set; }

        public CustomerCreatedEvent(Guid id)
        {
            CustomerID = id;
            AggregateId = id;
        }
    }
}
