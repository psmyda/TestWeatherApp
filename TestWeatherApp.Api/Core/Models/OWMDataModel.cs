using Newtonsoft.Json.Linq;

namespace TestWeatherApp.Api.Core.Models
{
    public class OWMDataModel
    {
        public OWMDataModel(string json)
        {
            JObject jObject = JObject.Parse(json);
            JToken jMain = jObject["main"];
            Temperature = (float)jMain["temp"];
            Humidity = (float)jMain["humidity"];
            City = (string)jObject["name"];
        }

        public float Temperature { get; set; }
        public float Humidity { get; set; }
        public string City { get; set; }

    }
}