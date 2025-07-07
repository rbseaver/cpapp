using System.Text.RegularExpressions;

namespace CPApp.Tests.Integration
{
    [TestClass]
    public sealed partial class WhenCallingVersionController
    {
#pragma warning disable SYSLIB1045 // Convert to 'GeneratedRegexAttribute'.
        private static readonly Regex SemVerRegex = new("^\\d+\\.\\d+\\.\\d+(-[A-Za-z0-9\\-.]+)?(\\+[A-Za-z0-9\\-.]+)?$");
#pragma warning restore SYSLIB1045 // Convert to 'GeneratedRegexAttribute'.

        private static readonly string Endpoint = "/version";

        [TestMethod]
        public async Task ShouldRetrieveFullVersionString()
        {
            // Arrange  
            using var factory = new IntegrationTestWebApplicationFactory<Program>();
            using var client = factory.CreateClient();

            // Act  
            var response = await client.GetAsync(Endpoint);
            var responseString = await response.Content.ReadAsStringAsync();

            // Assert  
            response.EnsureSuccessStatusCode();


            StringAssert.Matches(responseString, SemVerRegex);
        }
    }
}
