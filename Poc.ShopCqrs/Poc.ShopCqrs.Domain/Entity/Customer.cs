using Poc.ShopCqrs.Domain.Entity.Base;

namespace Poc.ShopCqrs.Domain.Entity
{
    public class Customer : EntityBase
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
    }
}
