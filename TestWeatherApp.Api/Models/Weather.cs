namespace TestWeatherApp.Api.Models
{
    public class Weather
    {
        public Location Location { get; set; }
        public Temperature Temperature { get; set; }
        public float Humidity { get; set; }
    }
}