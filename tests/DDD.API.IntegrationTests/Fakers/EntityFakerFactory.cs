using DDD.API.IntegrationTests.Common.Abstract;
using DDD.Infra.Data.Contexts;
using DDD.API.IntegrationTests.Fakers.Entities;

namespace DDD.API.IntegrationTests.Fakers
{
    public class EntityFakerFactory
    {
        private readonly DDDContext _context;

        public EntityFakerFactory(TestBase test)
        {
            _context = test.DbContext;
        }
        public CustomerFaker Customer() => new CustomerFaker(_context);
        public ProductFaker Product() => new ProductFaker(_context);
    }
}