using Xunit;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http.Headers;
using DDD.API;
using DDD.API.IntegrationTests.Common.Utils;
using DDD.Infra.Data.Contexts;

namespace DDD.API.IntegrationTests
{
    public class DDDAPIFixture : ICollectionFixture<DDDAPIFixture>, IAsyncLifetime
    {
        public Request Request { get; private set; }
        public HttpClient Client { get; private set; }
        public TestServer Server { get; private set; }
        public DDDContext DbContext { get; private set; }

        public readonly IConfiguration Configuration;
        public readonly IServiceProvider Services;

        public DDDAPIFixture()
        {
            var projectName = "DDD.API";
            Configuration = ConfigurationLoader.GetConfiguration(projectName, "Test");

            var webHostBuilder = new WebHostBuilder()
                .UseContentRoot(ProjectExplorer.GetDirectory(projectName))
                .ConfigureTestServices(ConfigureTestServices)
                .UseConfiguration(Configuration)
                .UseEnvironment("Test")
                .UseStartup(typeof(Startup));

            Server = new TestServer(webHostBuilder);
            Services = Server.Services;
            DbContext = Services.GetRequiredService<DDDContext>();
            Client = Server.CreateClient();
            Client.BaseAddress = new Uri($"https://localhost:8000");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Request = new Request(Client);
        }

        public async Task InitializeAsync()
        {
            try
            {
                await DbContext.Database.EnsureCreatedAsync();
            }
            catch (Exception)
            {
                await DbContext.Database.EnsureDeletedAsync();
                throw;
            }
        }

        private void ConfigureTestServices(IServiceCollection services) { }

        public async Task DisposeAsync()
        {
            await DbContext.Database.EnsureDeletedAsync();
            await DbContext.DisposeAsync();
            Client.Dispose();
            Server.Dispose();
        }
    }
}