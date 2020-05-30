using DDD.Domain.interfaces.Repositories;
using DDD.Domain.interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;
        public ServiceBase(IRepositoryBase<TEntity> repository) => _repository = repository;

        public async Task Add(TEntity entity)
        {
            await _repository.Add(entity);
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task Update(TEntity entity)
        {
            await _repository.Update(entity);
        }

        public async Task Remove(TEntity entity)
        {
            await _repository.Remove(entity);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
