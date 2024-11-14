using MediatR;
using Poc.ShopCqrs.Domain.Events;
using Poc.ShopCqrs.Domain.Exceptions;
using Poc.ShopCqrs.Domain.Interfaces.Cache;
using Poc.ShopCqrs.Domain.Interfaces.Repository;
using modelCache = Poc.ShopCqrs.Domain.ModelCache;

namespace Poc.ShopCqrs.Application.Customer.Events.Handlers
{
    public class CustomerEventHandler(ICustomerCache cache, ICustomerRepository repository) : INotificationHandler<CustomerCreatedEvent>
    {
        private readonly ICustomerCache _cache = cache;
        private readonly ICustomerRepository _repository = repository;

        public async Task Handle(CustomerCreatedEvent notification, CancellationToken cancellationToken)
        {
            var customerCriado = await _repository.BuscarPorId(notification.CustomerID);

            if (customerCriado is null)
                throw new CustomerException("Cliente nao encontrado na base.");

            var customerCache = new modelCache.Customer
            { 
                ID = notification.CustomerID, 
                Name = customerCriado.Name,
                Email = customerCriado.Email
            };

            await _cache.SetCache(notification.CustomerID.ToString(), customerCache);
        }
    }
}
