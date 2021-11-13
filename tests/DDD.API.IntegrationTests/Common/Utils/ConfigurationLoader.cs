using Microsoft.Extensions.Configuration;
using System;

namespace DDD.API.IntegrationTests.Common.Utils
{
    public static class ConfigurationLoader
    {
        public static IConfiguration GetConfiguration(string projectName, string environment = default)
        {
            if (string.IsNullOrWhiteSpace(environment))
                environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
            return new ConfigurationBuilder()
                .SetBasePath(ProjectExplorer.GetDirectory(projectName))
                .AddJsonFile($"appsettings.{environment}.json", false)
                .Build();
        }
    }
}