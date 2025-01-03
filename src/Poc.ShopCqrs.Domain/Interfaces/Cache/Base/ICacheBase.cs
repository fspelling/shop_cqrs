﻿namespace Poc.ShopCqrs.Domain.Interfaces.Cache.Base
{
    public interface ICacheBase<T>
    {
        Task SetCache(string id, T value, TimeSpan? expery = null);
        Task<T?> GetCache(string id);
        Task RemoveCache(string id);
    }
}
