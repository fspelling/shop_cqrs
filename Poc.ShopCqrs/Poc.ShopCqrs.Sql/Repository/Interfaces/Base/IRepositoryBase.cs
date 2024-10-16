﻿using Poc.ShopCqrs.Domain.Entity.Base;

namespace Poc.ShopCqrs.Sql.Repository.Interfaces.Base
{
    public interface IRepositoryBase<Entity> where Entity : EntityBase
    {
        Task Inserir(Entity entidade);
        Task Atualizar(Entity entidade);
        Task<IList<Entity>> Listar();
        Task<Entity?> BuscarPorId(string id);
        Task Remover(string id);
    }
}
