using MediatR;
using Poc.ShopCqrs.Application.Queries.Responses;

namespace Poc.ShopCqrs.Application.Queries.Requests
{
    public class FindCustomerByIdRequest : IRequest<FindCustomerByIdResponse>
    {
        public required string Id { get; set; }
    }
}
