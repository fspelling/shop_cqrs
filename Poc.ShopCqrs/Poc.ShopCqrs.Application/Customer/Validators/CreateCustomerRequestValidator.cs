using FluentValidation;
using Poc.ShopCqrs.Application.Customer.Commands.Requests;

namespace Poc.ShopCqrs.Application.Customer.Validators
{
    public class CreateCustomerRequestValidator : AbstractValidator<CreateCustomerRequest>
    {
        public CreateCustomerRequestValidator()
        {
            RuleFor(request => request.Name).NotNull().WithMessage("Nome do usuario nao informado");
            RuleFor(request => request.Email).NotNull().WithMessage("Email do usuario nao informado");
        }
    }
}
