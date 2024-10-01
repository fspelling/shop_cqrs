using Microsoft.EntityFrameworkCore;
using Poc.ShopCqrs.Sql;

namespace Poc.ShopCqrs.API
{
    public static class ProgramExtension
    {
        public static void ConfigureInjectDependency(this WebApplicationBuilder builder)
        {
        }

        public static void ConfigureEntityFrameworkSql(this WebApplicationBuilder builder)
            => builder.Services.AddDbContext<ShopDbContext>(db => db.UseSqlServer("TODO"));

        public static void ConfigureValidators(this WebApplicationBuilder builder)
        {
        }
    }
}
