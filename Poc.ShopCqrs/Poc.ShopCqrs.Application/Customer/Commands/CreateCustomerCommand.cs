using Poc.ShopCqrs.Domain.Messaging;

namespace Poc.ShopCqrs.Application.Customer.Commands
{
    public class CreateCustomerCommand : Command
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
    }
}
