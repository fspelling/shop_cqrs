using Poc.ShopCqrs.Domain.Messaging;

namespace Poc.ShopCqrs.Domain.Entity.Base
{
    public abstract class EntityBase
    {
        private List<Event> _domainEvents;

        public string ID { get; private set; } = Guid.NewGuid().ToString();
        public IReadOnlyCollection<Event> DomainEvents => _domainEvents?.AsReadOnly();

        public void AddDomainEvent(Event domainEvent)
        {
            _domainEvents = _domainEvents ?? new List<Event>();
            _domainEvents.Add(domainEvent);
        }

        public void RemoveDomainEvent(Event domainEvent)
            => _domainEvents?.Remove(domainEvent);

        public void ClearDomainEvents()
            => _domainEvents?.Clear();
    }
}
