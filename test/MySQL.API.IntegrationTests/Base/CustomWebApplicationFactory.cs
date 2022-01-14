using MySQL.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Xunit;

namespace MySQL.API.IntegrationTests.Base
{

    [Collection("Database")]
    public class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        //test comment
        private readonly DbFixture _dbFixture;

        public CustomWebApplicationFactory(DbFixture dbFixture)
            => _dbFixture = dbFixture;

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Test"); 
            builder.ConfigureAppConfiguration((context, config) =>
            {
                config.AddInMemoryCollection(new[]
                {
                    new KeyValuePair<string, string>(
                        "ConnectionStrings:ApplicationConnectionString", _dbFixture.ApplicationConnString),
                });
            });
            builder.ConfigureAppConfiguration((context, config) =>
            {
                config.AddInMemoryCollection(new[]
                {
                    new KeyValuePair<string, string>(
                        "ConnectionStrings:IdentityConnectionString", _dbFixture.IdentityConnString)
                });
            });
            builder.ConfigureAppConfiguration((context, config) =>
            {
                config.AddInMemoryCollection(new[]
                {
                    new KeyValuePair<string, string>(
                        "ConnectionStrings:HealthCheckConnectionString", _dbFixture.HealthCheckConnString)
                });
            });
            builder.ConfigureAppConfiguration((context, config) =>
            {
                config.AddInMemoryCollection(new[]
                {
                    new KeyValuePair<string, string>(
                        "CacheConfiguration:AbsoluteExpirationInHours", "1")
                });
            });
            builder.ConfigureAppConfiguration((context, config) =>
            {
                config.AddInMemoryCollection(new[]
                {
                    new KeyValuePair<string, string>(
                        "CacheConfiguration:SlidingExpirationInMinutes", "30")
                });
            });
        }
    }
}
