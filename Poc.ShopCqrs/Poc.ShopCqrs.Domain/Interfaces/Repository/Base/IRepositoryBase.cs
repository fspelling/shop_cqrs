using Poc.ShopCqrs.Domain.Entity.Base;

namespace Poc.ShopCqrs.Domain.Interfaces.Repository.Base
{
    public interface IRepositoryBase<Entity> where Entity : EntityBase
    {
        Task Inserir(Entity entidade);
        Task Atualizar(Entity entidade);
        Task<IList<Entity>> Listar();
        Task<Entity?> BuscarPorId(Guid id);
        Task Remover(Guid id);
    }
}
