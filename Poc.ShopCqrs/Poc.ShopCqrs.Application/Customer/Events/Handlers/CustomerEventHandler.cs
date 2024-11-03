using MediatR;
using Poc.ShopCqrs.Cache.Interfaces;
using Poc.ShopCqrs.Domain.Exceptions;
using Poc.ShopCqrs.Sql.Repository.Interfaces;

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

            var customerCache = new Poc.ShopCqrs.Cache.ModelCache.Customer
            {
                ID = notification.CustomerID,
                Name = customerCriado.Name,
                Email = customerCriado.Email
            };

            await _cache.SetCache(notification.CustomerID, customerCache);
        }
    }
}
