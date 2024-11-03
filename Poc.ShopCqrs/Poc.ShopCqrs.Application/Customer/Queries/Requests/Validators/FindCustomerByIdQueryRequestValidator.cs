using FluentValidation;
using Poc.ShopCqrs.Application.Customer.Queries.Requests;

namespace Poc.ShopCqrs.Application.Customer.Queries.Requests.Validators
{
    public class FindCustomerByIdQueryRequestValidator : AbstractValidator<FindCustomerByIdQueryRequest>
    {
        public FindCustomerByIdQueryRequestValidator()
            => RuleFor(request => request.Id).NotNull().WithMessage("id do usuario nao informado");
    }
}
