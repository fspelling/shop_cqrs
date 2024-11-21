using Poc.ShopCqrs.Data.Context;
using Poc.ShopCqrs.Data.Repository;
using Poc.ShopCqrs.Domain.Enums;

namespace Poc.ShopCqrs.Data.Factories
{
    public class RepositoryFactory(ShopDbContext dbContext)
    {
        private readonly ShopDbContext _dbContext = dbContext;

        public object CreateRepository(EntityEnum type)
        {
            return type switch
            {
                EntityEnum.Customer => new CustomerRepository(_dbContext),
                _ => throw new ArgumentException("Tipo de repositório inválido.")
            };
        }
    }

}
