using FluentValidation;
using Poc.ShopCqrs.Application.Customer.Commands.Requests;

namespace Poc.ShopCqrs.Application.Customer.Commands.Requests.Validators
{
    public class CreateCustomerCommandRequestValidator : AbstractValidator<CreateCustomerCommandRequest>
    {
        public CreateCustomerCommandRequestValidator()
        {
            RuleFor(request => request.Name).NotNull().WithMessage("Nome do usuario nao informado");
            RuleFor(request => request.Email).NotNull().WithMessage("Email do usuario nao informado");
        }
    }
}
