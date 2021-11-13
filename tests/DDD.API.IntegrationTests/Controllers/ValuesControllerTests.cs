using DDD.API.IntegrationTests;
using DDD.API.IntegrationTests.Common.Abstract;
using System;
using System.Threading.Tasks;
using Xunit;

namespace DDD.API.IntegrationTests.Controllers
{
    public class ValuesControllerTests : TestBase
    {
        public ValuesControllerTests(DDDAPIFixture fixture) : base(fixture, "api/values") { }
        
        [Fact]
        public async Task ShouldGetValuesAsync()
        {
            var (response, result) = await Request.GetAsync<String>(Uri);
        
            response.EnsureSuccessStatusCode();
            Assert.NotNull(result);
        }
    }
}