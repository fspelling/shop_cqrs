using FluentValidation;
using MediatR;
using Poc.ShopCqrs.Application.Customer.Queries.Requests;
using Poc.ShopCqrs.Application.Customer.Queries.Responses;
using Poc.ShopCqrs.Domain.Exceptions;
using Poc.ShopCqrs.Domain.Extensions;
using Poc.ShopCqrs.Domain.Interfaces.Cache;

namespace Poc.ShopCqrs.Application.Customer.Queries.Handlers
{
    public class CustomerQueryHandler
    (
        ICustomerCache customerCache,
        IValidator<FindCustomerByIdQueryRequest> findCustomerByIdRequestValidator
    ) : IRequestHandler<FindCustomerByIdQueryRequest, FindCustomerByIdQueryResponse>
    {
        private readonly ICustomerCache _customerCache = customerCache;
        private readonly IValidator<FindCustomerByIdQueryRequest> _findCustomerByIdRequestValidator = findCustomerByIdRequestValidator;

        public async Task<FindCustomerByIdQueryResponse> Handle(FindCustomerByIdQueryRequest request, CancellationToken cancellationToken)
        {
            await _findCustomerByIdRequestValidator.ValidarRequestException<FindCustomerByIdQueryRequest, CustomerException>(request);

            var customer = await _customerCache.GetCache(request.Id);

            if (customer is null)
                throw new CustomerException("cliente nao encontrado na base.");

            return new FindCustomerByIdQueryResponse { Id = customer.ID, Email = customer.Email, Name = customer.Name };
        }
    }
}
