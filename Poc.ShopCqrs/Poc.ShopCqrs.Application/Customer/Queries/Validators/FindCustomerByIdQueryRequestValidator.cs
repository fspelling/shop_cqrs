using FluentValidation;

namespace Poc.ShopCqrs.Application.Customer.Queries.Validators
{
    public class FindCustomerByIdQueryRequestValidator : AbstractValidator<FindCustomerByIdQuery>
    {
        public FindCustomerByIdQueryRequestValidator()
            => RuleFor(request => request.Id).NotNull().WithMessage("id do usuario nao informado");
    }
}
