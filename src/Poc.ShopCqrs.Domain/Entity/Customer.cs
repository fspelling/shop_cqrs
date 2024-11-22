using Poc.ShopCqrs.Domain.Core.Entity;
using System.Text.Json.Serialization;

namespace Poc.ShopCqrs.Domain.Entity
{
    public class Customer : EntityBase
    {
        public string? Name { get; private set; }
        public string? Email { get; private set; }

        public Customer()
        {
        }

        [JsonConstructor]
        public Customer(string name, string email, string id = null!) : base(id)
        {
            Name = name;
            Email = email;
        }
    }
}