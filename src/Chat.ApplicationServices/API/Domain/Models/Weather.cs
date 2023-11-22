
global using DomainWeather = Chat.ApplicationServices.API.Domain.Models.Weather;
//global using ClientWeather = Chat.ApplicationServices.Components.OpenWeather.Models.OpenWeatherResponse;


namespace Chat.ApplicationServices.API.Domain.Models
{
    public class Weather
    {
        public float Temperature { get; set; }

        public string Description { get; set; }
    }
}