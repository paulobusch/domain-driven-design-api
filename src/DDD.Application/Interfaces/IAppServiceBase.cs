using System.Collections.Generic;
using System.Threading.Tasks;

namespace DDD.Application.Interfaces
{
    public interface IAppServiceBase<TEntity> where TEntity : class
    {
        Task Add(TEntity entity);
        Task<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task Update(TEntity entity);
        Task Remove(TEntity entity);
        void Dispose();
    }
}
