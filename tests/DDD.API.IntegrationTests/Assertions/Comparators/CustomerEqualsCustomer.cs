using DDD.API.IntegrationTests.Common.Utils;
using DDD.Domain.Entities;

namespace DDD.API.IntegrationTests.Assertions.Comparators
{
    public class CustomerEqualsCustomer
    {
        public void Equals(Customer source, Customer target)
        {
            AssertExtensions.AreEqualObjects(source, target, ignore: new [] { nameof(source.Id) });
        }
    }
}