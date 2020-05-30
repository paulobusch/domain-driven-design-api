using DDD.Application.Interfaces;
using DDD.Domain.Entities;
using DDD.Domain.interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Application
{
    public class ProductAppService : AppServiceBase<Product>, IProductAppService
    {
        private readonly IProductService _productService;

        public ProductAppService(IProductService productService) : base(productService)
        {
            _productService = productService;
        }

        public async Task<IEnumerable<Product>> FindByName(string name)
        {
            return await _productService.FindByName(name);
        }
    }
}
