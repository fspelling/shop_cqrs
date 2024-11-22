using Poc.ShopCqrs.Domain.Core.Messaging;
using Poc.ShopCqrs.Domain.Enums;
using Poc.ShopCqrs.Domain.Events;
using System.Text.Json;

namespace Poc.ShopCqrs.Domain.Factories
{
    public static class EventFactory
    {
        public static Event CreateCustomerEvent(CustomerEventEnum customerEvent, string dataJson)
        {
            return customerEvent switch
            {
                CustomerEventEnum.CustomerCreatedEvent => JsonSerializer.Deserialize<CustomerCreatedEvent>(dataJson)!,
                _ => throw new NotImplementedException()
            };
        }
    }
}
