using DDD.Domain.Entities;
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
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(DDDContext context) : base(context) { }

        public async Task<IEnumerable<Product>> FindByName(string name)
        {
            return await Db.Products.Where(p => p.Name == name).ToArrayAsync();
        }
    }
}
