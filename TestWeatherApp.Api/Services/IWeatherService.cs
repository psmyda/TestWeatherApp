using TestWeatherApp.Api.Models;

namespace TestWeatherApp.Api.Services
{
    public interface IWeatherService
    {
        Weather GetWeather(string country, string city);
    }
}