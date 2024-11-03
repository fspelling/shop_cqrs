using Microsoft.Extensions.Caching.Distributed;
using Poc.ShopCqrs.Cache.Caches.Base;
using Poc.ShopCqrs.Domain.Interfaces.Cache;
using Poc.ShopCqrs.Domain.ModelCache;

namespace Poc.ShopCqrs.Cache.Caches
{
    public class CustomerCache(IDistributedCache cache) : CacheBase<Customer>(cache), ICustomerCache
    {
    }
}
