namespace OrderInventory.Api.Services;

public class WeatherSummaryService
{
    public string GetSummary(int temperatureC)
    {
        if (temperatureC < 10)
        {
            return "Cold";
        }

        if (temperatureC < 25)
        {
            return "Mild";
        }

        return "Hot";
    }
}