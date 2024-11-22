using Poc.ShopCqrs.Domain.Core.Entity;
using Poc.ShopCqrs.Domain.Entity;
using Poc.ShopCqrs.Domain.Enums;
using System.Text.Json;

namespace Poc.ShopCqrs.Domain.Factories
{
    public static class EntityFactory
    {
        public static EntityBase CreateEntity(EntityEnum entity, string dataJson)
        {
            return entity switch
            {
                EntityEnum.Customer => JsonSerializer.Deserialize<Customer>(dataJson)!,
                _ => throw new NotImplementedException()
            };
        }
    }
}
