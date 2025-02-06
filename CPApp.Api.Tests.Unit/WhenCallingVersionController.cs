using CPApp.Api.Controllers;
using CPApp.Lib.Interfaces;
using NSubstitute;

namespace CPApp.Api.Tests.Unit
{
    [TestClass]
    public sealed class WhenCallingVersionController
    {
        [TestMethod]
        public async Task ShouldFullReturnVersionString()
        {
            // Arrange
            var versionService = Substitute.For<IVersionService>();
            versionService.GetFullVersion().Returns(Task.FromResult("1.0.0+whoah"));

            // Act
            VersionController controller = new(versionService);
            string version = await controller.Get();

            // Assert
            Assert.AreEqual("1.0.0+whoah", version);
        }
    }
}
