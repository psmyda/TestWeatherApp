using FluentAssertions;
using NSubstitute;
using System.Web.Http.Results;
using TestWeatherApp.Api.Controllers.api;
using TestWeatherApp.Api.Models;
using TestWeatherApp.Api.Services;
using Xunit;

namespace TestWeatherApp.Test.Controllers
{
    public class WeatherControllerTests
    {
        private WeatherController _weatherController;

        public WeatherControllerTests()
        {
            var mockWeatherService = Substitute.For<IWeatherService>();

            var weather = new Weather
            {
                Location = new Location
                {
                    City = "Poland",
                    Country = "Warsaw"
                },
                Temperature = new Temperature
                {
                    Format = "Celsius",
                    Value = 10
                },
                Humidity = 95
            };

            mockWeatherService.GetWeather("Poland", "Warsaw").Returns(weather);

            _weatherController = new WeatherController(mockWeatherService);
        }

        [Fact]
        public void Get_CountryAndCityProvidedCorrectly_ShouldReturnWeatherObject()
        {


            var result = _weatherController.Get("Poland", "Warsaw");

            result.Should().BeOfType<OkNegotiatedContentResult<Weather>>();
        }

        [Fact]
        public void Get_WrongCountryNameWasProvided_ShouldReturnBadRequest()
        {
            var result = _weatherController.Get("Germany", "Berlin");

            result.Should().BeOfType<BadRequestErrorMessageResult>();

        }

        [Fact]
        public void Get_WrongCityNameWasProvided_ShouldReturnEmptyResponse()
        {
            var result = _weatherController.Get("Poland", "Wwaarrssaaww");

            result.Should().BeOfType<BadRequestErrorMessageResult>();


        }



    }
}
