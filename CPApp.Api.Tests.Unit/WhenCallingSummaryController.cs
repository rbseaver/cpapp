using CPApp.Api.Controllers;
using CPApp.Lib;
using CPApp.Lib.Interfaces;
using CPApp.Lib.Models;
using FluentAssertions;
using NSubstitute;

namespace CPApp.Api.Tests.Unit;

[TestClass]
public class WhenCallingSummaryController
{
    [TestMethod]
    public async Task AndNoDateSuppliedItShouldReturnMostRecentData()
    {
        // Arrange
        DateTime summaryDate = DateTime.Now.AddDays(-1);
        var summaryService = Substitute.For<ISummaryService>();
        SummaryReading summaryReading = new()
        {
            Date = summaryDate,
            Pressure =
            new()
            {
                MedianPressure = 11.0,
                Pressure95 = 12.6,
                Pressure99_5 = 13.5,
            },
            Events = new()
            {
                AHI = .96,
                CentralApneaEvents = 5,
                ObstructiveApneaEvents = 2,
                HypopneaEvents = 3,
            }
        };
        summaryService.GetSummaryReading().Returns(Task.FromResult(summaryReading));

        var controller = new SummaryController(summaryService);

        // Act
        var result = await controller.Get();

        // Assert
        result.Should().Satisfy<SummaryReading>(x => x.Should().Be(summaryReading));
    }
}
