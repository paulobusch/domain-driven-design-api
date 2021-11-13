using DDD.API.IntegrationTests.Common.Utils;
using DDD.Domain.Entities;

namespace DDD.API.IntegrationTests.Assertions.Comparators
{
    public class ProductEqualsProduct
    {
        public void Equals(Product source, Product target)
        {
            AssertExtensions.AreEqualObjects(source, target, new [] { nameof(source.Id) });
        }
    }
}