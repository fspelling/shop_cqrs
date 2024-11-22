using Poc.ShopCqrs.Domain.Core.Messaging;
using System.Text.Json.Serialization;

namespace Poc.ShopCqrs.Domain.Events
{
    public class CustomerCreatedEvent : Event
    {
        public DateTime DataCriacao { get; private set; } = DateTime.Now;
        public string CustomerID { get; private set; }

        public CustomerCreatedEvent(string id)
        {
            CustomerID = id;
            AggregateId = id;
        }

        [JsonConstructor]
        public CustomerCreatedEvent(string customerID, string aggregateId)
        {
            CustomerID = customerID;
            AggregateId = aggregateId;
        }
    }
}
