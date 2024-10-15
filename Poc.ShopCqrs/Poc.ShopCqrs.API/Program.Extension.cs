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
            var assemblys = new List<Assembly>
            { 
                Assembly.Load("Poc.ShopCqrs.Sql"),
                Assembly.Load("Poc.ShopCqrs.Service"),
                Assembly.Load("Poc.ShopCqrs.Application"),
            };

            builder.Services.AddInjectServicesFromAssembly(assemblys);
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.Load("Poc.ShopCqrs.Application")));
        }

        public static void ConfigureEntityFrameworkSql(this WebApplicationBuilder builder)
            => builder.Services.AddDbContext<ShopDbContext>(db => db.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
    }
}
