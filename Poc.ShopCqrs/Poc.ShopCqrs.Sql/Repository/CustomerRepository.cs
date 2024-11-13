using Poc.ShopCqrs.Domain.Entity;
using Poc.ShopCqrs.Domain.Interfaces.Repository;
using Poc.ShopCqrs.Sql.Context;
using Poc.ShopCqrs.Sql.Repository.Base;

namespace Poc.ShopCqrs.Sql.Repository
{
    public class CustomerRepository(ShopDbContext dbContext) : RepositoryBase<Customer>(dbContext), ICustomerRepository
    {
    }
}
