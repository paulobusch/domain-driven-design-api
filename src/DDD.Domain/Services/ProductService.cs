using DDD.Domain.Entities;
using DDD.Domain.interfaces.Repositories;
using DDD.Domain.interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Services
{
    public class ProductService : ServiceBase<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(
            IProductRepository repository
        ) : base(repository) => _productRepository = repository;

        public async Task<IEnumerable<Product>> FindByName(string name)
        {
            return await _productRepository.FindByName(name);
        }
    }
}
