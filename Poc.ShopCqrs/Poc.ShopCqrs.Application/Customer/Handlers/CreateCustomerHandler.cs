using FluentValidation;
using MediatR;
using Poc.ShopCqrs.Application.Customer.Commands.Requests;
using Poc.ShopCqrs.Application.Customer.Commands.Responses;
using Poc.ShopCqrs.Domain.Exceptions;
using Poc.ShopCqrs.Domain.Extensions;
using Poc.ShopCqrs.Service.Interfaces;
using Poc.ShopCqrs.Sql.Repository.Interfaces;
using EntityDb = Poc.ShopCqrs.Domain.Entity;

namespace Poc.ShopCqrs.Application.Customer.Handlers
{
    public class CreateCustomerHandler
    (
        ICustomerRepository customerRepository, 
        IEmailService emailService, 
        IValidator<CreateCustomerRequest> createCustomerValidator
    ) : IRequestHandler<CreateCustomerRequest, CreateCustomerResponse>
    {
        private readonly ICustomerRepository _customerRepository = customerRepository;
        private readonly IEmailService _emailService = emailService;
        private readonly IValidator<CreateCustomerRequest> _createCustomerValidator = createCustomerValidator;

        public async Task<CreateCustomerResponse> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
        {
            await _createCustomerValidator.ValidarRequestException<CreateCustomerRequest, CustomerException>(request);

            var customer = new EntityDb.Customer() { Name = request.Name, Email = request.Email };

            await _customerRepository.Inserir(customer);
            await _emailService.Send(request.Email);

            return new CreateCustomerResponse
            {
                Customer = customer,
                DateCriacao = DateTime.Now
            };
        }
    }
}
