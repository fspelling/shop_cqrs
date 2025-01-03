﻿namespace Poc.ShopCqrs.API.Configurations
{
    public static class CacheConfig
    {
        public static void ConfigureRedis(this WebApplicationBuilder builder)
            => builder.Services.AddStackExchangeRedisCache(opt => opt.Configuration = "localhost:6379");
    }
}
