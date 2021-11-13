using DDD.Application.Interfaces;
using DDD.Domain.interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DDD.Application
{
    public class AppServiceBase<TEntity> : IDisposable, IAppServiceBase<TEntity> where TEntity : class
    {
        private readonly IServiceBase<TEntity> _serviceBase;
        public AppServiceBase(IServiceBase<TEntity> serviceBase) => _serviceBase = serviceBase; 

        public async Task Add(TEntity entity)
        {
            await _serviceBase.Add(entity);
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _serviceBase.GetById(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _serviceBase.GetAll();
        }

        public async Task Update(TEntity entity)
        {
            await _serviceBase.Update(entity);
        }

        public async Task Remove(TEntity entity)
        {
            await _serviceBase.Remove(entity);
        }

        public void Dispose()
        {
            _serviceBase.Dispose();
        }
    }
}
