namespace Poc.ShopCqrs.Application.Customer.Queries.Responses
{
    public class FindCustomerByIdResponse
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
    }
}
