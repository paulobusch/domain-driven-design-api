using DDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Application.Interfaces
{
    public interface IProductAppService : IAppServiceBase<Product>
    {
        Task<IEnumerable<Product>> FindByName(string name);
    }
}
