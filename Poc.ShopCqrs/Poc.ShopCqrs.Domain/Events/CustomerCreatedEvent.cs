using Poc.ShopCqrs.Domain.Messaging;

namespace Poc.ShopCqrs.Domain.Events
{
    public class CustomerCreatedEvent : Event
    {
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public required string CustomerID { get; set; }
    }
}
