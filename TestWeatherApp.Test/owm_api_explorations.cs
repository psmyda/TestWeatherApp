using System;
using System.Net.Http;
using Xunit;

namespace TestWeatherApp.Test
{
    public class owm_api_explorations
    {
        string execute(string query)
        {
            string url = "http://api.openweathermap.org/data/2.5/weather?appid=8319c6a2e0d2a41af8777dbb75321b0d&q=" +
                         query;

            return new HttpClient().GetAsync(url).Result.Content.ReadAsStringAsync().Result;

        }

        [Fact]
        public void returns_response()
        {
            string result = execute("Warsaw,pl");

            Console.WriteLine(result);

            Assert.NotEmpty(result);
        }
    }
}
