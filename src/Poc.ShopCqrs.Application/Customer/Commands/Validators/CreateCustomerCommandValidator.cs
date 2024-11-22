using FluentValidation;

namespace Poc.ShopCqrs.Application.Customer.Commands.Validators
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(request => request.Name).NotNull().WithMessage("Nome do usuario nao informado");
            RuleFor(request => request.Email).NotNull().WithMessage("Email do usuario nao informado");
        }
    }
}
