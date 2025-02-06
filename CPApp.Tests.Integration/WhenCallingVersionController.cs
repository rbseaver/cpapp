using CPApp.Lib.Interfaces;
using CPApp.Lib.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CPApp.Tests.Integration
{
    [TestClass]
    public sealed class WhenCallingVersionController
    {
        [TestMethod]
        public async Task ShouldRetrieveFullVersionString()
        {
            // Arrange
            var builder = WebApplication.CreateBuilder();
            builder.Services.AddSingleton<IVersionService, VersionService>();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
            var client = app.CreateClient();
            // Act
            var response = await client.GetAsync("/version");
            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.AreEqual("1.0.0", responseString);
        }
    }
}
