﻿using FluentValidation;
using MediatR;
using Poc.ShopCqrs.Domain.Events;
using Poc.ShopCqrs.Domain.Exceptions;
using Poc.ShopCqrs.Domain.Extensions;
using Poc.ShopCqrs.Domain.Interfaces.EventBus;
using Poc.ShopCqrs.Domain.Interfaces.Repository;
using EntityDb = Poc.ShopCqrs.Domain.Entity;

namespace Poc.ShopCqrs.Application.Customer.Commands.Handlers
{
    public class CustomerCommandHandler
    (
        IEventBus eventBus,
        ICustomerRepository customerRepository,
        IValidator<CreateCustomerCommand> createCustomerValidator
    ) : IRequestHandler<CreateCustomerCommand>
    {
        private readonly IEventBus _eventBus = eventBus;
        private readonly ICustomerRepository _customerRepository = customerRepository;
        private readonly IValidator<CreateCustomerCommand> _createCustomerValidator = createCustomerValidator;

        public async Task Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            await _createCustomerValidator.ValidarRequestException<CreateCustomerCommand, CustomerException>(request);

            var customer = new EntityDb.Customer() { Name = request.Name, Email = request.Email };

            await _customerRepository.Inserir(customer);

            await _eventBus.Publish(new CustomerCreatedEvent { CustomerID = customer.ID });
        }
    }
}
