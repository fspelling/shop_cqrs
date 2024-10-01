using Poc.ShopCqrs.Domain.Entity;

namespace Poc.ShopCqrs.Application.Commands.Responses
{
    public class CreateCustomerResponse
    {
        public required Customer Customer { get; set; }
        public DateTime DateCriacao { get; set; }
    }
}
