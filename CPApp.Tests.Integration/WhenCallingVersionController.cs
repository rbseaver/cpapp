using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Text.RegularExpressions;

namespace CPApp.Tests.Integration
{
    [TestClass]
    public sealed partial class WhenCallingVersionController
    {
#pragma warning disable SYSLIB1045 // Convert to 'GeneratedRegexAttribute'.
        private static readonly Regex SemVerRegex = new("^\\d+\\.\\d+\\.\\d+(-[A-Za-z0-9\\-.]+)?(\\+[A-Za-z0-9\\-.]+)?$");
#pragma warning restore SYSLIB1045 // Convert to 'GeneratedRegexAttribute'.

        [TestMethod]
        public async Task ShouldRetrieveFullVersionString()
        {
            // Arrange  
            await using var factory = new CustomWebApplicationFactory<Program>();
            using var client = factory.CreateClient();

            // Act  
            var response = await client.GetAsync("/version");

            // Assert  
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            StringAssert.Matches(responseString, SemVerRegex);
        }
    }
}
