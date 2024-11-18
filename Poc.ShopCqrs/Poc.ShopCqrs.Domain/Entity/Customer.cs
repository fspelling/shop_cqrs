using Poc.ShopCqrs.Domain.Core.Entity;

namespace Poc.ShopCqrs.Domain.Entity
{
    public class Customer(string name, string email) : EntityBase
    {
        public string Name { get; private set; } = name;
        public string Email { get; private set; } = email;

        private void When(Customer eventEntity)
        {
            Name = eventEntity.Name;
            Email = eventEntity.Email;
        }
    }
}
