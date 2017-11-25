using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Web.Http;

namespace TestWeatherApp.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            var serializerSettings = config.Formatters.JsonFormatter.SerializerSettings;
            serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            serializerSettings.Formatting = Formatting.Indented;

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "WeatherRequest",
                routeTemplate: "api/weather/{country}/{city}",
                defaults: new
                {
                    controller = "Weather",
                    action = "Get",
                    country = String.Empty,
                    city = String.Empty
                }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
