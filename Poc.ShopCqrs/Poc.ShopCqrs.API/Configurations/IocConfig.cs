using FluentValidation;
using MediatR;
using Poc.ShopCqrs.Application.Configuration;
using Poc.ShopCqrs.Application.Customer.Commands;
using Poc.ShopCqrs.Application.Customer.Commands.Handlers;
using Poc.ShopCqrs.Application.Customer.Commands.Validators;
using Poc.ShopCqrs.Application.Customer.Events.Handlers;
using Poc.ShopCqrs.Application.Customer.Queries;
using Poc.ShopCqrs.Application.Customer.Queries.Handlers;
using Poc.ShopCqrs.Application.Customer.Queries.Responses;
using Poc.ShopCqrs.Bus;
using Poc.ShopCqrs.Cache.Caches;
using Poc.ShopCqrs.Data.EventSourcing;
using Poc.ShopCqrs.Data.Repository;
using Poc.ShopCqrs.Data.Repository.EventSourcing;
using Poc.ShopCqrs.Domain.Core.Events;
using Poc.ShopCqrs.Domain.Events;
using Poc.ShopCqrs.Domain.Interfaces.Cache;
using Poc.ShopCqrs.Domain.Interfaces.EventBus;
using Poc.ShopCqrs.Domain.Interfaces.Repository;
using System.Reflection;

namespace Poc.ShopCqrs.API.Configurations
{
    public static class IocConfig
    {
        public static void ConfigureInjectDependency(this WebApplicationBuilder builder)
        {
            //var assemblys = new List<Assembly>
            //{
            //    Assembly.Load("Poc.ShopCqrs.Domain"),
            //    Assembly.Load("Poc.ShopCqrs.Domain.Core"),
            //    Assembly.Load("Poc.ShopCqrs.Bus"),
            //    Assembly.Load("Poc.ShopCqrs.Data"),
            //    Assembly.Load("Poc.ShopCqrs.Cache"),
            //    Assembly.Load("Poc.ShopCqrs.Application"),
            //};

            //builder.Services.AddInjectServicesFromAssembly(assemblys);

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.Load("Poc.ShopCqrs.Application")));

            RegisterAutoMappers(builder.Services);
            RegisterBus(builder.Services);
            RegisterRepositorys(builder.Services);
            RegisterCache(builder.Services);
            RegisterDataEventSourcing(builder.Services);
            RegisterEvents(builder.Services);
            RegisterCommands(builder.Services);
            RegisterQuerys(builder.Services);
        }

        #region Register Dependencys

        private static void RegisterAutoMappers(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
        }

        private static void RegisterBus(IServiceCollection services)
        {
            services.AddScoped<IEventBus, EventBus>();
        }

        private static void RegisterEvents(IServiceCollection services)
        {
            services.AddScoped<INotificationHandler<CustomerCreatedEvent>, CustomerEventHandler>();
        }

        private static void RegisterCommands(IServiceCollection services)
        {
            services.AddScoped<IValidator<CreateCustomerCommand>, CreateCustomerCommandValidator>();
            services.AddScoped<IRequestHandler<CreateCustomerCommand>, CustomerCommandHandler>();
        }

        private static void RegisterQuerys(IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<FindCustomerByIdQuery, FindCustomerByIdQueryResponse>, CustomerQueryHandler>();
        }

        private static void RegisterRepositorys(IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
        }

        private static void RegisterCache(IServiceCollection services)
        {
            services.AddScoped<ICustomerCache, CustomerCache>();
        }

        private static void RegisterDataEventSourcing(IServiceCollection services)
        {
            services.AddScoped<IEventStore, EventStore>();
            services.AddScoped<IEventStoreRepository, EventStoreRepository>();
        }

        #endregion
    }
}
