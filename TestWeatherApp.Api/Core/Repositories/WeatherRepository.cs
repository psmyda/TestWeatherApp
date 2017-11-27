using System.Globalization;
using System.Linq;
using System.Net.Http;
using TestWeatherApp.Api.Core.Models;

namespace TestWeatherApp.Api.Core.Repositories
{
    public class WeatherRepository : IWeatherRepository
    {
        private const string Url = "http://api.openweathermap.org/data/2.5/weather?appid=8319c6a2e0d2a41af8777dbb75321b0d&units=metric&q=";

        public Weather GetWeather(string country, string city)
        {
            // get country code
            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            CultureInfo countryInfo = cultures.FirstOrDefault(culture =>
                new RegionInfo(culture.LCID).EnglishName ==
                System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(country.ToLower()));

            if (countryInfo == null)
                return null;

            var urlQuery = Url + $"{city},{countryInfo.TwoLetterISOLanguageName}";

            var result = new HttpClient().GetAsync(urlQuery).Result.Content.ReadAsStringAsync().Result;

            var data = new OWMDataModel(result);

            var weather = new Weather
            {
                Location = new Location
                {
                    Country = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(country.ToLower()),
                    City = data.City
                },
                Temperature = new Temperature
                {
                    Format = "Celsius",
                    Value = data.Temperature
                },
                Humidity = data.Humidity
            };

            return weather;
        }
    }
}