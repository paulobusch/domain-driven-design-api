using DDD.API.IntegrationTests.Common.Abstract;
using DDD.Domain.Entities;
using DDD.Infra.Data.Contexts;
using System;

namespace DDD.API.IntegrationTests.Fakers.Entities 
{
    public class CustomerFaker : EntityFakerBase<Customer> 
    {
        public CustomerFaker(DDDContext context) : base(context)
        {
            RuleFor(c => c.Name, f => f.Person.FullName)
                .RuleFor(c => c.LastName, f => f.Person.LastName)
                .RuleFor(c => c.Email, f => f.Person.Email)
                .RuleFor(c => c.CreatedDate, f => f.Date.Past())
                .RuleFor(c => c.Active, f => f.Random.Bool());
        } 
    }
}