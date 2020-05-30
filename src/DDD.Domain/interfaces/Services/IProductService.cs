using DDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.interfaces.Services
{
    public interface IProductService : IServiceBase<Product>
    {
        Task<IEnumerable<Product>> FindByName(string name);
    }
}
