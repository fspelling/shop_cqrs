using MediatR;
using Poc.ShopCqrs.Application.Customer.Queries.Responses;

namespace Poc.ShopCqrs.Application.Customer.Queries.Requests
{
    public class FindCustomerByIdRequest : IRequest<FindCustomerByIdResponse>
    {
        public required string Id { get; set; }
    }
}
