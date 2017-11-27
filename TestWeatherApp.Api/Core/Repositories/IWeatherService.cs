using TestWeatherApp.Api.Core.Models;

namespace TestWeatherApp.Api.Core.Repositories
{
    public interface IWeatherService
    {
        Weather GetWeather(string country, string city);
    }
}