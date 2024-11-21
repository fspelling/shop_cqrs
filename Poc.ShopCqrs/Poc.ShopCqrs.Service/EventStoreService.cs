using Poc.ShopCqrs.Data.Context;
using Poc.ShopCqrs.Data.Factories;
using Poc.ShopCqrs.Domain.Core.Events;
using Poc.ShopCqrs.Domain.Enums;
using Poc.ShopCqrs.Domain.Exceptions;
using Poc.ShopCqrs.Domain.Factories;
using Poc.ShopCqrs.Domain.Interfaces.EventBus;
using Poc.ShopCqrs.Domain.Interfaces.Repository;
using Poc.ShopCqrs.Domain.Interfaces.Repository.EventSourcing;
using Poc.ShopCqrs.Domain.Interfaces.Service;

namespace Poc.ShopCqrs.Service
{
    public class EventStoreService(IEventStoreRepository eventStoreRepository, ICustomerRepository customerRepository, IEventBus eventBus, ShopDbContext dbContext) : IEventStoreService
    {
        private readonly IEventStoreRepository _eventStoreRepository = eventStoreRepository;
        private readonly ICustomerRepository _customerRepository = customerRepository;
        private readonly IEventBus _eventBus = eventBus;
        private readonly ShopDbContext _dbContext = dbContext;

        public async Task<List<StoredEvent>> ObterHistoryPorAggregateId(string aggregateId)
            => await _eventStoreRepository.All(aggregateId);

        public async Task RestaureEntity(string aggregateId)
        {
            var events = await _eventStoreRepository.All(aggregateId);
            var orderedEvents = events?.OrderBy(e => e.TimeStamp);

            if (orderedEvents is null)
                throw new EventStoreException("Nenhum evento encontrado para o AggregateId especificado.");

            await AplicarEventData(orderedEvents.ToList());
        }

        #region Metodos Auxiliares

        private dynamic TransformarEntityBase(string entityName)
        {
            var entityType = Type.GetType($"Poc.ShopCqrs.Cache.ModelCache.{entityName}, Poc.ShopCqrs.Cache");

            var entity = Activator.CreateInstance(entityType!)!;
            return entity;
        }

        private async Task AplicarEventData(List<StoredEvent> orderedEvents)
        {
            foreach (var storedEvent in orderedEvents)
            {
                var entityFactory = (dynamic)EntityFactory.CreateEntity((EntityEnum)Enum.Parse(typeof(EntityEnum), storedEvent.EntityName!), storedEvent.DataEntity!);

                if (entityFactory == null)
                    throw new EventStoreException("Falha na desserialização da entidade do evento.");

                var factory = new RepositoryFactory(dbContext);
                var customerRepository = (dynamic)factory.CreateRepository((EntityEnum)Enum.Parse(typeof(EntityEnum), storedEvent.EntityName!));

                await customerRepository.Atualizar(entityFactory);

                var eventFactory = EventFactory.CreateCustomerEvent((CustomerEventEnum)Enum.Parse(typeof(CustomerEventEnum), storedEvent.MessageType!), storedEvent.Data!);

                await _eventBus.Publish(eventFactory);
            }
        }

        #endregion
    }
}
