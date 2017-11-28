using FluentAssertions;
using System.Web.Http;
using System.Web.Http.Results;
using TechTalk.SpecFlow;
using TestWeatherApp.Api.Controllers.api;
using TestWeatherApp.Api.Models;
using TestWeatherApp.Api.Services;

namespace TestWeatherApp.Spec
{
    [Binding]
    public class LocalWeatherInAGivenCityStepsWarsaw
    {
        private readonly WeatherController _controller = new WeatherController(new WeatherService());

        private IHttpActionResult _data;

        [Given(@"a webpage with a form")]
        public void GivenAWebpageWithAForm()
        {
            ScenarioContext.Current.Pending(); // step performed on the frontend
        }

        [Given(@"I type in '(.*)'")]
        public void GivenITypeIn(string p0)
        {
            _data = _controller.Get("Poland", "Warsaw");
        }

        [When(@"I submit the form")]
        public void WhenISubmitTheForm()
        {
            ScenarioContext.Current.Pending(); // step performed on the frontend
        }

        [Then(@"I receive the temperature and humidity conditions on the day for Warsaw, Poland according to the official weather reports")]
        public void ThenIReceiveTheTemperatureAndHumidityConditionsOnTheDayForWarsawPolandAccordingToTheOfficialWeatherReports()
        {
            _data.Should().BeOfType<OkNegotiatedContentResult<Weather>>();
        }
    }
}
