using TestWeatherApp.Api.Core.Models;

namespace TestWeatherApp.Api.Core.Repositories
{
    public class WeatherService : IWeatherService
    {

        private readonly IWeatherRepository _weatherRepository;

        public WeatherService(IWeatherRepository weatherRepository)
        {
            _weatherRepository = weatherRepository;
        }

        public Weather GetWeather(string country, string city)
        {
            return _weatherRepository.GetWeather(country, city);


        }
    }
}