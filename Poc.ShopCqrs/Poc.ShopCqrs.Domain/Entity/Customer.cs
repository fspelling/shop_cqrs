using Poc.ShopCqrs.Domain.Entity.Base;

namespace Poc.ShopCqrs.Domain.Entity
{
    public class Customer(string nome, string email) : EntityBase
    {
        public string Name { get; private set; } = nome;
        public string Email { get; private set; } = email;
    }
}
