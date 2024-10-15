using MediatR;
using Poc.ShopCqrs.Application.Customer.Commands.Responses;

namespace Poc.ShopCqrs.Application.Customer.Commands.Requests
{
    public class CreateCustomerRequest : IRequest<CreateCustomerResponse>
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
    }
}
