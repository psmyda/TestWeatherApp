using TestWeatherApp.Api.Core.Models;

namespace TestWeatherApp.Api.Core.Repositories
{
    public interface IWeatherRepository
    {
        Weather GetWeather(string country, string city);
    }
}