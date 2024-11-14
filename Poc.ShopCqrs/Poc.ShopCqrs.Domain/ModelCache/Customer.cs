namespace Poc.ShopCqrs.Domain.ModelCache
{
    public class Customer
    {
        public required Guid ID { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
    }
}
