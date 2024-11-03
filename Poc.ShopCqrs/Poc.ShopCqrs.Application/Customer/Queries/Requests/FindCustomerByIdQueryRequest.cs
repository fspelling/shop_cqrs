using Poc.ShopCqrs.Application.Customer.Queries.Responses;
using Poc.ShopCqrs.Domain.Messaging;

namespace Poc.ShopCqrs.Application.Customer.Queries.Requests
{
    public class FindCustomerByIdQueryRequest : Query<FindCustomerByIdQueryResponse>
    {
        public required string Id { get; set; }
    }
}
