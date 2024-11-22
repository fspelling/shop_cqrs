using Poc.ShopCqrs.Data.Context;
using Poc.ShopCqrs.Data.Repository;
using Poc.ShopCqrs.Domain.Enums;

namespace Poc.ShopCqrs.Data.Factories
{
    public static class RepositoryFactory
    {
        public static object CreateRepository(ShopDbContext dbContext, EntityEnum type)
        {
            return type switch
            {
                EntityEnum.Customer => new CustomerRepository(dbContext),
                _ => throw new ArgumentException("Tipo de repositório inválido.")
            };
        }
    }

}
