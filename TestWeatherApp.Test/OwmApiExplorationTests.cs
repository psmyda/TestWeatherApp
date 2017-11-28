using System;
using System.Net.Http;
using Xunit;

namespace TestWeatherApp.Test
{
    public class OwmApiExplorationTests 
    {
        [Fact]
        public void Test_CallOpenWeatherApi_ShouldReturnResponse()
        {
            const string url = "http://api.openweathermap.org/data/2.5/weather?appid=8319c6a2e0d2a41af8777dbb75321b0d&q=" +
                               "Warsaw, pl";

            var result = new HttpClient().GetAsync(url).Result.Content.ReadAsStringAsync().Result;

            Console.WriteLine(result);

            Assert.NotEmpty(result);
        }

    }
}
