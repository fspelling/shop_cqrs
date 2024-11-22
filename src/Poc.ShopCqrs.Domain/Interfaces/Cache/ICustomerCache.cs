using Poc.ShopCqrs.Domain.Interfaces.Cache.Base;
using Poc.ShopCqrs.Domain.ModelCache;

namespace Poc.ShopCqrs.Domain.Interfaces.Cache
{
    public interface ICustomerCache : ICacheBase<Customer>
    {
    }
}
