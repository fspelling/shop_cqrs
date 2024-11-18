using System.Reflection;

namespace Poc.ShopCqrs.Domain.Core.Entity
{
    public abstract class EntityBase
    {
        public Guid ID { get; private set; } = Guid.NewGuid();

        public virtual void ApplyEvent(object @event)
        {
            var method = this.GetType().GetMethod("When", BindingFlags.NonPublic | BindingFlags.Instance, null, [@event.GetType()], null);
            method?.Invoke(this, [@event]);
        }
    }
}
