using Poc.ShopCqrs.Domain.Core.Messaging;

namespace Poc.ShopCqrs.Domain.Events
{
    public class CustomerCreatedEvent : Event
    {
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public required string CustomerID { get; set; }
    }
}
