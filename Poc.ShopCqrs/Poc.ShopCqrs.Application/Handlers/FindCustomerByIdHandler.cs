using MediatR;
using Poc.ShopCqrs.Application.Queries.Requests;
using Poc.ShopCqrs.Application.Queries.Responses;
using Poc.ShopCqrs.Domain.Exceptions;
using Poc.ShopCqrs.Sql.Repository.Interfaces;

namespace Poc.ShopCqrs.Application.Handlers
{
    public class FindCustomerByIdHandler(ICustomerRepository customerRepository) : IRequestHandler<FindCustomerByIdRequest, FindCustomerByIdResponse>
    {
        private readonly ICustomerRepository _customerRepository = customerRepository;

        public async Task<FindCustomerByIdResponse> Handle(FindCustomerByIdRequest request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.BuscarPorId(request.Id);

            if (customer is null)
                throw new CustomerException("cliente nao encontrado na base.");

            return new FindCustomerByIdResponse { Id = customer.ID, Email = customer.Email, Name = customer.Name };
        }
    }
}
