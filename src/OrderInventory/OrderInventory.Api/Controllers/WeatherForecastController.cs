using Microsoft.AspNetCore.Mvc;
using OrderInventory.Api.Services;

namespace OrderInventory.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly WeatherSummaryService _weatherSummaryService;

        public WeatherForecastController(
            WeatherSummaryService weatherSummaryService)
        {
            _weatherSummaryService = weatherSummaryService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            var forecasts = Enumerable.Range(1, 5)
                .Select(index =>
                {
                    var temperatureC = Random.Shared.Next(-20, 55);

                    return new WeatherForecast
                    {
                        Date = DateOnly.FromDateTime(
                            DateTime.Now.AddDays(index)),
                        TemperatureC = temperatureC,
                        Summary = _weatherSummaryService.GetSummary(temperatureC)
                    };
                })
                .ToArray();

            return forecasts;
        }
    }
}
