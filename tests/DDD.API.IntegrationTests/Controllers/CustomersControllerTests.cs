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
    public class CustomersControllerTests : TestBase
    {
        public CustomersControllerTests(DDDAPIFixture fixture) : base(fixture, "api/customers") { }
        
        [Fact]
        public async Task ShouldReturnManyAsync()
        {
            var customer = EntityFactory.Customer().Save();
        
            var (response, result) = await Request.GetAsync<IEnumerable<Customer>>(Uri);
        
            response.EnsureSuccessStatusCode();
            Assert.NotEqual(default, result);
            Assert.NotEmpty(result);
            var modelResponse = result.Single(c => c.Id == customer.Id);
            CompareFactory.CustomerEqualsCustomer().Equals(customer, modelResponse);
        }
        
        [Fact]
        public async Task ShouldReturnByIdAsync()
        {
            var customer = EntityFactory.Customer().Save();
        
            var (response, result) = await Request.GetAsync<Customer>(new Uri($"{Uri}/{customer.Id}"));
        
            response.EnsureSuccessStatusCode();
            Assert.NotNull(result);
            CompareFactory.CustomerEqualsCustomer().Equals(customer, result);
        }
        
        [Fact]
        public async Task ShouldCreateAsync()
        {
            var customerRequest = ModelFactory.Customer().Generate();
        
            var response = await Request.PostAsync(Uri, customerRequest);
        
            response.EnsureSuccessStatusCode();

            var customer = DbContext.Customers.ToArray()
                .OrderBy(p => p.Id)
                .Last();
            CompareFactory.CustomerEqualsCustomer().Equals(customerRequest, customer);
        }
        
        [Fact]
        public async Task ShouldUpdateAsync()
        {
            var customer = EntityFactory.Customer().Save();
            var customerRequest = ModelFactory.Customer().Generate();
        
            var response = await Request.PutAsync(new Uri($"{Uri}/{customer.Id}"), customerRequest);
        
            response.EnsureSuccessStatusCode();
              
            await DbContext.Entry(customer).ReloadAsync();
            CompareFactory.CustomerEqualsCustomer().Equals(customerRequest, customer);
        }
        
        [Fact]
        public async Task ShouldRemoveAsync()
        {
            var customer = EntityFactory.Customer().Save();
        
            var response = await Request.DeleteAsync(new Uri($"{Uri}/{customer.Id}"));
        
            response.EnsureSuccessStatusCode();
            var existCustomer = await DbContext.Customers.AnyAsync(c => c.Id == customer.Id);
            Assert.False(existCustomer);
        }
    }
}