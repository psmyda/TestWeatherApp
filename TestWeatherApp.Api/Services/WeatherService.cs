using Newtonsoft.Json;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using TestWeatherApp.Api.Models;

namespace TestWeatherApp.Api.Services
{
    public class WeatherService : IWeatherService
    {

        string apiKey = "8319c6a2e0d2a41af8777dbb75321b0d";
        private string apiRequestUrl = "http://api.openweathermap.org/data/2.5/weather?q=";

        public Weather GetWeather(string country, string city)
        {
            // get country two digit code in ISO3166 (OpenMapWeatherRequirement)
            var countryInfo = GetCountryInfo(country);

            if (countryInfo == null)
                return null;

            var apiResponse = GetApiResponse(city);

            if (apiResponse.cod != 200) return null;
            var weather = PrepareWeatherResponse(apiResponse);
            return weather;
        }

        private static Weather PrepareWeatherResponse(OpenWeatherMapResponse response)
        {
            var weather = new Weather
            {
                Location = new Location
                {
                    Country = response.sys.country,
                    City = response.name
                },
                Temperature = new Temperature
                {
                    Format = "Celsius", // this option wasn't in requirements - I would add this as a dictionary and let user select it on front-end
                    Value = response.main.temp
                },
                Humidity = response.main.humidity
            };
            return weather;
        }

        private OpenWeatherMapResponse GetApiResponse(string city)
        {
            var urlQuery = apiRequestUrl + $"{city}&appid={apiKey}&units=metric";

            var apiResponse = new HttpClient().GetAsync(urlQuery).Result.Content.ReadAsStringAsync().Result;

            var rootObject = JsonConvert.DeserializeObject<OpenWeatherMapResponse>(apiResponse);

            return rootObject;
        }

        private static CultureInfo GetCountryInfo(string country)
        {
            var cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            var countryInfo = cultures.FirstOrDefault(culture =>
                new RegionInfo(culture.LCID).EnglishName ==
                System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(country.ToLower()));
            return countryInfo;
        }
    }
}