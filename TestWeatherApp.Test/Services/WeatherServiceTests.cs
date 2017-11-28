using NSubstitute;
using TestWeatherApp.Api.Services;

namespace TestWeatherApp.Test.Services
{
    public class WeatherServiceTests
    {
        private IWeatherService _weatherService;

        public WeatherServiceTests()
        {
            _weatherService = Substitute.For<IWeatherService>();
        }
    }
}
