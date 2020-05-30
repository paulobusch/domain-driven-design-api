using DDD.Application.Interfaces;
using DDD.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.API.Controllers
{
    public class ProductsController : DDDControllerBase
    {
        private readonly IProductAppService _productApp;
        
        public ProductsController(IProductAppService productApp)
        {
            _productApp = productApp;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> ListAsync()
        {
            return (await _productApp.GetAll()).ToArray();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetAsync(int id)
        {
            return await _productApp.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] Product product)
        {
            await _productApp.Add(product);
            return Ok(new { Success = true });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, [FromBody] Product product) { 
            product.Id = id;
            await _productApp.Update(product);
            return Ok(new { Success = true });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveAsync(int id)
        {
            var customer = await _productApp.GetById(id);
            await _productApp.Remove(customer);
            return Ok(new { Success = true });
        }
    }
}