using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Poc.ShopCqrs.Domain.Core.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInjectServicesFromAssembly(this IServiceCollection services, List<Assembly> assemblies)
        {
            assemblies.ForEach(assembly =>
            {
                var serviceTypes = assembly.GetTypes()
                                           .Where(t => t.IsClass &&
                                                       !t.IsAbstract &&
                                                       !t.IsGenericType &&
                                                       t.GetInterfaces().Any() &&
                                                       !typeof(Exception).IsAssignableFrom(t))
                                           .ToList();

                serviceTypes.ForEach(type =>
                {
                    var interfaces = type.GetInterfaces();
                    foreach (var @interface in interfaces)
                    {
                        if (!services.Any(s => s.ServiceType == @interface && s.ImplementationType == type))
                            services.AddScoped(@interface, type);
                    }
                });
            });
        }
    }
}
