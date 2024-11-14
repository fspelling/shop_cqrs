using Poc.ShopCqrs.Domain.Entity.Base;

namespace Poc.ShopCqrs.Domain.Entity
{
    public class Customer(string name, string email) : EntityBase
    {
        public string Name { get; private set; } = name;
        public string Email { get; private set; } = email;
    }
}
