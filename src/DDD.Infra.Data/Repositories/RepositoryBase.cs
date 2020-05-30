using DDD.Domain.interfaces;
using DDD.Domain.interfaces.Repositories;
using DDD.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly DDDContext Db;
        public RepositoryBase(DDDContext db) => Db = db;

        public async Task Add(TEntity entity)
        {
            Db.Set<TEntity>().Add(entity);
            await Db.SaveChangesAsync();
        }
        
        public async Task<TEntity> GetById(int id)
        {
            return await Db.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await Db.Set<TEntity>().ToArrayAsync();
        }

        public async Task Update(TEntity entity)
        {
            Db.Entry(entity).State = EntityState.Modified;
            await Db.SaveChangesAsync();
        }

        public async Task Remove(TEntity entity)
        {
            Db.Set<TEntity>().Remove(entity);
            await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
