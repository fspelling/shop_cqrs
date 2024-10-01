using Poc.ShopCqrs.Application.Commands.Requests;
using Poc.ShopCqrs.Application.Commands.Responses;

namespace Poc.ShopCqrs.Application.Handlers
{
    public interface ICreateCustomerHandler
    {
        CreateCustomerResponse Handle(CreateCustomerRequest request);
    }
}
