using CPApp.Lib.Interfaces;
using CPApp.Lib.Services;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace CPApp.Tests.Integration
{
    public class IntegrationTestWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(Microsoft.AspNetCore.Hosting.IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Register test-specific services if needed
                services.AddSingleton<IVersionService, VersionService>();
            });
        }
    }
}