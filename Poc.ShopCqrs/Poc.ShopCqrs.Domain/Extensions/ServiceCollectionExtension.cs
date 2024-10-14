using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Poc.ShopCqrs.Domain.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInjectServicesFromAssembly(this IServiceCollection services, Assembly assembly)
        {
            var servicesTypes = assembly.GetTypes().Where(t => t.IsClass && !t.IsAbstract && t.GetInterfaces().Any()).ToList();

            servicesTypes.ForEach(type =>
            {
                var interfaces = type.GetInterfaces().ToList();
                interfaces.ForEach(@interface => services.AddScoped(@interface, type));
            });
        }
    }
}
