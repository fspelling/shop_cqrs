namespace Poc.ShopCqrs.Application.EventStore.Model.Input
{
    public class EventStoreRestaureInputModel
    {
        public required Guid EventStoreId { get; set; }
        public required Guid AggregateId { get; set; }
    }
}
