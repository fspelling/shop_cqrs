using Poc.ShopCqrs.Application.Customer.Commands.Responses;
using Poc.ShopCqrs.Domain.Messaging;

namespace Poc.ShopCqrs.Application.Customer.Commands.Requests
{
    public class CreateCustomerCommandRequest : Command<CreateCustomerCommandResponse>
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
    }
}
