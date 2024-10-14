using Microsoft.EntityFrameworkCore;
using Poc.ShopCqrs.Domain.Extensions;
using Poc.ShopCqrs.Sql;
using System.Reflection;

namespace Poc.ShopCqrs.API
{
    public static class ProgramExtension
    {
        public static void ConfigureInjectDependency(this WebApplicationBuilder builder)
        {
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            builder.Services.AddInjectServicesFromAssembly(Assembly.GetExecutingAssembly());
        }

        public static void ConfigureEntityFrameworkSql(this WebApplicationBuilder builder)
            => builder.Services.AddDbContext<ShopDbContext>(db => db.UseSqlServer("TODO"));

        public static void ConfigureValidators(this WebApplicationBuilder builder)
        {
        }
    }
}
