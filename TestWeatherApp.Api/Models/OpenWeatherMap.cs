using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace TestWeatherApp.Api.Models
{
    public class OpenWeatherMap
    {
        public OpenWeatherMap(string json)
        {
            JObject jObject = JObject.Parse(json);
            JToken jMain = jObject["main"];
            Temperature = (float)jMain["temp"];
            Humidity = (float)jMain["humidity"];
            City = (string)jObject["name"];
        }

        public string ApiResponse { get; set; }

        public float Temperature { get; set; }
        public float Humidity { get; set; }
        public string City { get; set; }

    }

    public class Coord
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }

    public class WeatherResponse
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class Main
    {
        public double temp { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
    }

    public class Wind
    {
        public double speed { get; set; }
        public double deg { get; set; }
    }

    public class Clouds
    {
        public int all { get; set; }
    }

    public class Sys
    {
        public int type { get; set; }
        public int id { get; set; }
        public double message { get; set; }
        public string country { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }

    public class OpenWeatherMapResponse
    {
        public Coord coord { get; set; }
        public List<Weather> weather { get; set; }
        public string @base { get; set; }
        public Main main { get; set; }
        public int visibility { get; set; }
        public Wind wind { get; set; }
        public Clouds clouds { get; set; }
        public int dt { get; set; }
        public Sys sys { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }
        public string message { get; set; }
    }
}