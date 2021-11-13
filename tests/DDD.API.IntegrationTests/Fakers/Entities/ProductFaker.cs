using DDD.API.IntegrationTests.Common.Abstract;
using DDD.Domain.Entities;
using DDD.Infra.Data.Contexts;

namespace DDD.API.IntegrationTests.Fakers.Entities
{
    public class ProductFaker : EntityFakerBase<Product> 
    {
        public ProductFaker(DDDContext context) : base(context)
        {
            RuleFor(p => p.Name, f => f.Person.FullName)
                .RuleFor(p => p.Price, f => f.Random.Decimal(0, 100))
                .RuleFor(p => p.Available, f => f.Random.Bool())
                .RuleFor(p => p.Customer, new CustomerFaker(context));
        } 
    }
}