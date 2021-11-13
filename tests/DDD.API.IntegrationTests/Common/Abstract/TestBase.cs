using DDD.API.IntegrationTests.Assertions;
using DDD.API.IntegrationTests.Common.Utils;
using DDD.API.IntegrationTests.Fakers;
using DDD.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DDD.API.IntegrationTests.Common.Abstract
{
    public class TestBase : IClassFixture<DDDAPIFixture>, IAsyncLifetime
    {
        public readonly Uri Uri;
        public readonly Request Request;
        public readonly DDDContext DbContext;

        public readonly ModelFakerFactory ModelFactory;
        public readonly EntityFakerFactory EntityFactory;
        public readonly CompareFactory CompareFactory;

        public TestBase(DDDAPIFixture fixture, string url)
        {
            Request = fixture.Request;
            DbContext = fixture.DbContext;
            Uri = new Uri($"{fixture.Client.BaseAddress}{url}");

            ModelFactory = new ModelFakerFactory();
            EntityFactory = new EntityFakerFactory(this);
            CompareFactory = new CompareFactory();
        }

        public async Task DisposeAsync()
        {
            await Task.CompletedTask;
        }

        public async Task InitializeAsync()
        {
            await Task.CompletedTask;
        }
    }
}