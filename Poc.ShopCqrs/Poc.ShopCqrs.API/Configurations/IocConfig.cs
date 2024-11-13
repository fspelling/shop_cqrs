using System.Reflection;
using Poc.ShopCqrs.Application.Configuration;
using Poc.ShopCqrs.Domain.Core.Extensions;

namespace Poc.ShopCqrs.API.Configurations
{
    public static class IocConfig
    {
        public static void ConfigureInjectDependency(this WebApplicationBuilder builder)
        {
            var assemblys = new List<Assembly>
            {
                Assembly.Load("Poc.ShopCqrs.Domain"),
                Assembly.Load("Poc.ShopCqrs.Domain.Core"),
                Assembly.Load("Poc.ShopCqrs.Bus"),
                Assembly.Load("Poc.ShopCqrs.Sql"),
                Assembly.Load("Poc.ShopCqrs.Cache"),
                Assembly.Load("Poc.ShopCqrs.Application"),
            };

            builder.Services.AddInjectServicesFromAssembly(assemblys);
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.Load("Poc.ShopCqrs.Application")));
        }
    }
}
