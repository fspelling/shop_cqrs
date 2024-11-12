using FluentValidation;
using MediatR;
using Poc.ShopCqrs.Application.Customer.Queries.Responses;
using Poc.ShopCqrs.Domain.Exceptions;
using Poc.ShopCqrs.Domain.Extensions;
using Poc.ShopCqrs.Domain.Interfaces.Cache;

namespace Poc.ShopCqrs.Application.Customer.Queries.Handlers
{
    public class CustomerQueryHandler
    (
        ICustomerCache customerCache,
        IValidator<FindCustomerByIdQuery> findCustomerByIdRequestValidator
    ) : IRequestHandler<FindCustomerByIdQuery, FindCustomerByIdQueryResponse>
    {
        private readonly ICustomerCache _customerCache = customerCache;
        private readonly IValidator<FindCustomerByIdQuery> _findCustomerByIdRequestValidator = findCustomerByIdRequestValidator;

        public async Task<FindCustomerByIdQueryResponse> Handle(FindCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            await _findCustomerByIdRequestValidator.ValidarRequestException<FindCustomerByIdQuery, CustomerException>(request);

            var customer = await _customerCache.GetCache(request.Id);

            if (customer is null)
                throw new CustomerException("cliente nao encontrado na base.");

            return new FindCustomerByIdQueryResponse { Id = customer.ID, Email = customer.Email, Name = customer.Name };
        }
    }
}
