using DDD.API.IntegrationTests;
using DDD.API.IntegrationTests.Common.Abstract;
using DDD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DDD.API.IntegrationTests.Controllers
{
    public class ProductsControllerTests : TestBase
    {
        public ProductsControllerTests(DDDAPIFixture fixture) : base(fixture, "api/products") { }
        
        [Fact]
        public async Task ShouldReturnManyAsync()
        {
            var product = EntityFactory.Product().Save();
        
            var (response, result) = await Request.GetAsync<IEnumerable<Product>>(Uri);
        
            response.EnsureSuccessStatusCode();
            Assert.NotEqual(default, result);
            Assert.NotEmpty(result);
            var modelResponse = result.Single(p => p.Id == product.Id);
            CompareFactory.ProductEqualsProduct().Equals(product, modelResponse);
        }
        
        [Fact]
        public async Task ShouldReturnByIdAsync()
        {
            var product = EntityFactory.Product().Save();
        
            var (response, result) = await Request.GetAsync<Product>(new Uri($"{Uri}/{product.Id}"));
        
            response.EnsureSuccessStatusCode();
            Assert.NotNull(result);
            CompareFactory.ProductEqualsProduct().Equals(product, result);
        }
        
        [Fact]
        public async Task ShouldCreateAsync()
        {
            var customer = EntityFactory.Customer().Save();
            var productRequest = ModelFactory.Product()
                .RuleFor(p => p.CustomerId, customer.Id)
                .Generate();
        
            var response = await Request.PostAsync(Uri, productRequest);
        
            response.EnsureSuccessStatusCode();
             
            var product = DbContext.Products.ToArray()
                .OrderBy(p => p.Id)
                .Last();
            CompareFactory.ProductEqualsProduct().Equals(productRequest, product);
        }
        
        [Fact]
        public async Task ShouldUpdateAsync()
        {
            var product = EntityFactory.Product().Save();
            var productRequest = ModelFactory.Product()
                .RuleFor(p => p.CustomerId, product.CustomerId)
                .Generate();
        
            var response = await Request.PutAsync(new Uri($"{Uri}/{product.Id}"), productRequest);
        
            response.EnsureSuccessStatusCode();
              
            await DbContext.Entry(product).ReloadAsync();
            CompareFactory.ProductEqualsProduct().Equals(productRequest, product);
        }
        
        [Fact]
        public async Task ShouldRemoveAsync()
        {
            var product = EntityFactory.Product().Save();
        
            var response = await Request.DeleteAsync(new Uri($"{Uri}/{product.Id}"));
        
            response.EnsureSuccessStatusCode();
            var existProduct = await DbContext.Products.AnyAsync(p => p.Id == product.Id);
            Assert.False(existProduct);
        }
    }
}