using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore.Internal;
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
using Poc.ShopCqrs.Domain.Interfaces.Repository.EventSourcing;
using Poc.ShopCqrs.Domain.Interfaces.Service;
using Poc.ShopCqrs.Service;
using System.Reflection;

namespace Poc.ShopCqrs.API.Configurations
{
    public static class IocConfig
    {
        public static void ConfigureInjectDependency(this WebApplicationBuilder builder)
        {
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.Load("Poc.ShopCqrs.Application")));

            RegisterAutoMappers(builder.Services);
            RegisterBus(builder.Services);
            RegisterServices(builder.Services);
            RegisterRepositorys(builder.Services);
            RegisterCache(builder.Services);
            RegisterDataEventSourcing(builder.Services);
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

        private static void RegisterCommands(IServiceCollection services)
        {
            services.AddScoped<IValidator<CreateCustomerCommand>, CreateCustomerCommandValidator>();
        }

        private static void RegisterQuerys(IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<FindCustomerByIdQuery, FindCustomerByIdQueryResponse>, CustomerQueryHandler>();
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IEventStoreService, EventStoreService>();
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
