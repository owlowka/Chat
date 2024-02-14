
global using DomainWeather = Chat.ApplicationServices.Domain.Models.Weather;
//global using ClientWeather = Chat.ApplicationServices.Components.OpenWeather.Models.OpenWeatherResponse;


namespace Chat.ApplicationServices.Domain.Models
{
    public class Weather
    {
        public float Temperature { get; set; }

        public string Description { get; set; }
    }
}