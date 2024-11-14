using Poc.ShopCqrs.Domain.Core.Messaging;

namespace Poc.ShopCqrs.Domain.Events
{
    public class CustomerCreatedEvent(Guid id) : Event
    {
        public DateTime DataCriacao { get; private set; } = DateTime.Now;
        public Guid CustomerID { get; private set; } = id;
    }
}
