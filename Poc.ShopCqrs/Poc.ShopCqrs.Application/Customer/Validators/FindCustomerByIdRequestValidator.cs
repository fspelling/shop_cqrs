using FluentValidation;
using Poc.ShopCqrs.Application.Customer.Queries.Requests;

namespace Poc.ShopCqrs.Application.Customer.Validators
{
    public class FindCustomerByIdRequestValidator : AbstractValidator<FindCustomerByIdRequest>
    {
        public FindCustomerByIdRequestValidator()
            => RuleFor(request => request.Id).NotNull().WithMessage("id do usuario nao informado");
    }
}
