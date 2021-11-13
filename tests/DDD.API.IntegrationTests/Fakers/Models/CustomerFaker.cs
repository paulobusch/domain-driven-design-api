using DDD.Domain.Entities;
using Bogus;

namespace DDD.API.IntegrationTests.Fakers.Models 
{
    public class CustomerFaker : Faker<Customer> 
    {
        public CustomerFaker()
        {
            RuleFor(c => c.Name, f => f.Person.FullName)
                .RuleFor(c => c.LastName, f => f.Person.LastName)
                .RuleFor(c => c.Email, f => f.Person.Email)
                .RuleFor(c => c.CreatedDate, f => f.Date.Past())
                .RuleFor(c => c.Active, f => f.Random.Bool());
        } 
    }
}