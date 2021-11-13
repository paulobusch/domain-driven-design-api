using DDD.API.IntegrationTests.Assertions.Comparators;
namespace DDD.API.IntegrationTests.Assertions
{
    public class CompareFactory
    {
        public CustomerEqualsCustomer CustomerEqualsCustomer() => new CustomerEqualsCustomer();
        public ProductEqualsProduct ProductEqualsProduct() => new ProductEqualsProduct();
    }
}