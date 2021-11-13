using DDD.Domain.Entities;
using Bogus;

namespace DDD.API.IntegrationTests.Fakers.Models 
{
    public class ProductFaker : Faker<Product> 
    {
        public ProductFaker()
        {
            RuleFor(p => p.Name, f => f.Person.FullName)
                .RuleFor(p => p.Price, f => f.Random.Decimal(0, 100))
                .RuleFor(p => p.Available, f => f.Random.Bool());
        } 
    }
}