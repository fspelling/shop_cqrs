﻿using Microsoft.EntityFrameworkCore;
using Poc.ShopCqrs.Data.Context;
using Poc.ShopCqrs.Domain.Core.Entity;
using Poc.ShopCqrs.Domain.Interfaces.Repository.Base;

namespace Poc.ShopCqrs.Data.Repository.Base
{
    public abstract class RepositoryBase<TEntity>(ShopDbContext dbContext) : IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        protected readonly ShopDbContext dbContext = dbContext;

        public async Task Atualizar(TEntity entidade)
        {
            dbContext.Entry(entidade).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }

        public async Task<TEntity?> BuscarPorId(string id)
            => await dbContext.Set<TEntity>().Where(e => e.ID == id).FirstOrDefaultAsync();

        public async Task Inserir(TEntity entidade)
        {
            dbContext.Entry(entidade).State = EntityState.Added;
            await dbContext.SaveChangesAsync();
        }

        public async Task<IList<TEntity>> Listar()
            => await dbContext.Set<TEntity>().ToListAsync();

        public async Task Remover(string id)
        {
            var entidade = await dbContext.Set<TEntity>().Where(e => e.ID == id).FirstOrDefaultAsync();

            dbContext.Entry(entidade!).State = EntityState.Deleted;
            await dbContext.SaveChangesAsync();
        }
    }
}
