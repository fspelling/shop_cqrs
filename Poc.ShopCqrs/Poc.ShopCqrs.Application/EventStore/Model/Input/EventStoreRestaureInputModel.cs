namespace Poc.ShopCqrs.Application.EventStore.Model.Input
{
    public class EventStoreRestaureInputModel
    {
        public required Guid AggregateId { get; set; }
        public required string EnityName { get; set; }
    }
}
