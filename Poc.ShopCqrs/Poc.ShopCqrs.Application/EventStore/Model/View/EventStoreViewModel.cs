using Poc.ShopCqrs.Domain.Core.Events;

namespace Poc.ShopCqrs.Application.EventStore.Model.View
{
    public class EventStoreViewModel
    {
        public required List<StoredEvent> EventsStore { get; set; }
    }
}
