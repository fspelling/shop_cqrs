using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Poc.ShopCqrs.Domain.Core.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInjectServicesFromAssembly(this IServiceCollection services, List<Assembly> assemblys)
        {
            assemblys.ForEach(assembly =>
            {
                var servicesTypes = assembly.GetTypes().Where(t => t.IsClass &&
                                                               !t.IsAbstract &&
                                                               !t.IsGenericType &&
                                                               t.GetInterfaces().Any() &&
                                                               !typeof(Exception).IsAssignableFrom(t)).ToList();

                servicesTypes.ForEach(type =>
                {
                    var interfaces = type.GetInterfaces().ToList();
                    interfaces.ForEach(@interface => services.AddScoped(@interface, type));
                });
            });
        }
    }
}
