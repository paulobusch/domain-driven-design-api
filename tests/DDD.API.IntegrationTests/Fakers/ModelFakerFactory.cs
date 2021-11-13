using DDD.API.IntegrationTests.Fakers.Models;
namespace DDD.API.IntegrationTests.Fakers
{
    public class ModelFakerFactory
    {
        public CustomerFaker Customer() => new CustomerFaker();
        public ProductFaker Product() => new ProductFaker();
    }
}