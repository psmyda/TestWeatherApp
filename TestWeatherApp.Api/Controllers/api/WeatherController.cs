using System.Web.Http;
using System.Web.Http.Cors;
using TestWeatherApp.Api.Core.Repositories;

namespace TestWeatherApp.Api.Controllers.api
{
    [EnableCors("http://localhost:4200", "*", "*")]
    public class WeatherController : ApiController
    {
        private readonly IWeatherService _weatherService;


        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }


        //GET /api/weather/{country}/{city}
        public IHttpActionResult Get(string country, string city)
        {
            var result = _weatherService.GetWeather(country, city);

            if (result == null)
                return BadRequest("You provided wrong country name");

            return Ok(result);
        }



    }
}
