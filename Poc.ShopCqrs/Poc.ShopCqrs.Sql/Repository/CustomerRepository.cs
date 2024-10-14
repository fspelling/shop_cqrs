using Poc.ShopCqrs.Domain.Entity;
using Poc.ShopCqrs.Sql.Repository.Base;
using Poc.ShopCqrs.Sql.Repository.Interfaces;

namespace Poc.ShopCqrs.Sql.Repository
{
    public class CustomerRepository(ShopDbContext dbContext) : RepositoryBase<Customer>(dbContext), ICustomerRepository
    {
    }
}
