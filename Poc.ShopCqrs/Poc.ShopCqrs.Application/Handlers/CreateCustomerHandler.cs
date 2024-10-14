using MediatR;
using Poc.ShopCqrs.Application.Commands.Requests;
using Poc.ShopCqrs.Application.Commands.Responses;
using Poc.ShopCqrs.Domain.Entity;
using Poc.ShopCqrs.Service.Interfaces;
using Poc.ShopCqrs.Sql.Repository.Interfaces;

namespace Poc.ShopCqrs.Application.Handlers
{
    public class CreateCustomerHandler(ICustomerRepository customerRepository, IEmailService emailService) : IRequestHandler<CreateCustomerRequest, CreateCustomerResponse>
    {
        private readonly ICustomerRepository _customerRepository = customerRepository;
        private readonly IEmailService _emailService = emailService;

        public async Task<CreateCustomerResponse> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
        {
            var customer = new Customer(request.Name, request.Email);

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
