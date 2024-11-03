using FluentValidation;
using MediatR;
using Poc.ShopCqrs.Application.Customer.Commands.Requests;
using Poc.ShopCqrs.Application.Customer.Commands.Responses;
using Poc.ShopCqrs.Application.Customer.Events;
using Poc.ShopCqrs.Domain.Exceptions;
using Poc.ShopCqrs.Domain.Extensions;
using Poc.ShopCqrs.Domain.Interfaces.Repository;
using Poc.ShopCqrs.Domain.Interfaces.Service;
using Poc.ShopCqrs.Domain.Messaging;
using EntityDb = Poc.ShopCqrs.Domain.Entity;

namespace Poc.ShopCqrs.Application.Customer.Commands.Handlers
{
    public class CustomerCommandHandler
    (
        IEventBus eventBus,
        ICustomerRepository customerRepository,
        IEmailService emailService,
        IValidator<CreateCustomerCommandRequest> createCustomerValidator
    ) : IRequestHandler<CreateCustomerCommandRequest, CreateCustomerCommandResponse>
    {
        private readonly IEventBus _eventBus = eventBus;
        private readonly ICustomerRepository _customerRepository = customerRepository;
        private readonly IEmailService _emailService = emailService;
        private readonly IValidator<CreateCustomerCommandRequest> _createCustomerValidator = createCustomerValidator;

        public async Task<CreateCustomerCommandResponse> Handle(CreateCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            await _createCustomerValidator.ValidarRequestException<CreateCustomerCommandRequest, CustomerException>(request);

            var customer = new EntityDb.Customer() { Name = request.Name, Email = request.Email };

            await _customerRepository.Inserir(customer);
            await _emailService.Send(request.Email);

            await _eventBus.Publish(new CustomerCreatedEvent { CustomerID = customer.ID });

            return new CreateCustomerCommandResponse
            {
                Customer = customer,
                DateCriacao = DateTime.Now
            };
        }
    }
}
