using FluentValidation;
using MediatR;
using Poc.ShopCqrs.Application.Customer.Queries.Requests;
using Poc.ShopCqrs.Application.Customer.Queries.Responses;
using Poc.ShopCqrs.Domain.Exceptions;
using Poc.ShopCqrs.Domain.Extensions;
using Poc.ShopCqrs.Sql.Repository.Interfaces;

namespace Poc.ShopCqrs.Application.Customer.Handlers
{
    public class FindCustomerByIdHandler
    (
        ICustomerRepository customerRepository, 
        IValidator<FindCustomerByIdRequest> findCustomerByIdRequestValidator
    ) : IRequestHandler<FindCustomerByIdRequest, FindCustomerByIdResponse>
    {
        private readonly ICustomerRepository _customerRepository = customerRepository;
        private readonly IValidator<FindCustomerByIdRequest> _findCustomerByIdRequestValidator = findCustomerByIdRequestValidator;

        public async Task<FindCustomerByIdResponse> Handle(FindCustomerByIdRequest request, CancellationToken cancellationToken)
        {
            await _findCustomerByIdRequestValidator.ValidarRequestException<FindCustomerByIdRequest, CustomerException>(request);

            var customer = await _customerRepository.BuscarPorId(request.Id);

            if (customer is null)
                throw new CustomerException("cliente nao encontrado na base.");

            return new FindCustomerByIdResponse { Id = customer.ID, Email = customer.Email, Name = customer.Name };
        }
    }
}
