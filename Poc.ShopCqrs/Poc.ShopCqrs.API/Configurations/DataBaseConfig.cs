using Microsoft.EntityFrameworkCore;
using Poc.ShopCqrs.Data.Context;

namespace Poc.ShopCqrs.API.Configurations
{
    public static class DataBaseConfig
    {
        public static void ConfigureEntityFrameworkSql(this WebApplicationBuilder builder)
            => builder.Services.AddDbContext<ShopDbContext>(db => db.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
    }
}
