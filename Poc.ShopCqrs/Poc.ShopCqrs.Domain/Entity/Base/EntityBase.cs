namespace Poc.ShopCqrs.Domain.Entity.Base
{
    public abstract class EntityBase
    {
        public Guid ID { get; private set; } = Guid.NewGuid();
    }
}
