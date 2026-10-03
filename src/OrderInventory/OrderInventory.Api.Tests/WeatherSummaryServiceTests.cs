using OrderInventory.Api.Services;
using Xunit;

namespace OrderInventory.Api.Tests;

public class WeatherSummaryServiceTests
{
    [Theory]
    [InlineData(9, "Cold")]
    [InlineData(10, "Mild")]
    [InlineData(24, "Mild")]
    [InlineData(25, "Hot")]
    public void GetSummary_WhenGivenTemperature_ReturnsExpectedSummary(
    int temperatureC,
    string expectedSummary)
    {
        // Arrange
        var service = new WeatherSummaryService();

        // Act
        var result = service.GetSummary(temperatureC);

        // Assert
        Assert.Equal(expectedSummary, result);
    }
}