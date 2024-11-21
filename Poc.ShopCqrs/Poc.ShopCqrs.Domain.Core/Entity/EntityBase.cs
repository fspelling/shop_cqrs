namespace Poc.ShopCqrs.Domain.Core.Entity
{
    public abstract class EntityBase
    {
        public string ID { get; protected set; }

        protected EntityBase(string id = null!) 
            => ID = id ?? Guid.NewGuid().ToString();
    }
}
