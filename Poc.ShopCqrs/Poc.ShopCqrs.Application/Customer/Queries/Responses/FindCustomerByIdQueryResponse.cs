namespace Poc.ShopCqrs.Application.Customer.Queries.Responses
{
    public class FindCustomerByIdQueryResponse
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
    }
}
