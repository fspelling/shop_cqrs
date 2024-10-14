using Poc.ShopCqrs.Domain.Entity;
using Poc.ShopCqrs.Sql.Repository.Interfaces.Base;

namespace Poc.ShopCqrs.Sql.Repository.Interfaces
{
    public interface ICustomerRepository : IRepositoryBase<Customer>
    {
    }
}
