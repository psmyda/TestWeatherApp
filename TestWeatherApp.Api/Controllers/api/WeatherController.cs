using System;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using TestWeatherApp.Api.Core.Models;

namespace TestWeatherApp.Api.Controllers.api
{
    public class WeatherController : ApiController
    {
        private string url = "http://api.openweathermap.org/data/2.5/weather?appid=8319c6a2e0d2a41af8777dbb75321b0d&units=metric&q=";

        //GET /api/weather/{country}/{city}
        public IHttpActionResult Get(string country, string city)
        {
            // get country code
            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            CultureInfo countryInfo = cultures.FirstOrDefault(culture =>
                new RegionInfo(culture.LCID).EnglishName ==
                System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(country.ToLower()));

            if (countryInfo == null)
                return BadRequest("You provided wrong country name");

            var urlQuery = url + $"{city},{countryInfo.TwoLetterISOLanguageName}";

            var result = new HttpClient().GetAsync(urlQuery).Result.Content.ReadAsStringAsync().Result;

            var data = new OWMDataModel(result);

            var weather = new Weather
            {
                Location = new Location
                {
                    Country = FirstCharToUpper(country),
                    City = data.City
                },
                Temperature = new Temperature
                {
                    Format = "Celsius",
                    Value = data.Temperature
                },
                Humidity = data.Humidity
            };

            return Ok(weather);
        }


        public static string FirstCharToUpper(string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("No string provided");
            return input.First().ToString().ToUpper() + input.Substring(1);
        }
    }
}
