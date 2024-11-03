using Microsoft.Extensions.Caching.Distributed;
using Poc.ShopCqrs.Cache.Caches.Base;
using Poc.ShopCqrs.Cache.Interfaces;
using Poc.ShopCqrs.Cache.ModelCache;

namespace Poc.ShopCqrs.Cache.Caches
{
    public class CustomerCache(IDistributedCache cache) : CacheBase<Customer>(cache), ICustomerCache
    {
    }
}
