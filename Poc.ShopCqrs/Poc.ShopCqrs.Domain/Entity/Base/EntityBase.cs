namespace Poc.ShopCqrs.Domain.Entity.Base
{
    public abstract class EntityBase
    {
        public string ID { get; private set; } = Guid.NewGuid().ToString();
    }
}
