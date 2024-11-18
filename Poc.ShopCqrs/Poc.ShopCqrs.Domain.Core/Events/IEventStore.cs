using Poc.ShopCqrs.Domain.Core.Entity;
using Poc.ShopCqrs.Domain.Core.Messaging;

namespace Poc.ShopCqrs.Domain.Core.Events
{
    public interface IEventStore
    {
        void Save<TEvent, TEntity>(TEvent @event, TEntity entity) where TEvent : Event where TEntity : EntityBase;
    }
}
