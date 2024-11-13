using Poc.ShopCqrs.Domain.Entity;
using Poc.ShopCqrs.Domain.Interfaces.Repository;
using Poc.ShopCqrs.Data.Context;
using Poc.ShopCqrs.Data.Repository.Base;

namespace Poc.ShopCqrs.Data.Repository
{
    public class CustomerRepository(ShopDbContext dbContext) : RepositoryBase<Customer>(dbContext), ICustomerRepository
    {
    }
}
