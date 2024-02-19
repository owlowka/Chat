
global using DomainWeather = Chat.Domain.Weather.Weather;
//global using ClientWeather = Chat.ApplicationServices.Components.OpenWeather.Models.OpenWeatherResponse;


namespace Chat.Domain.Weather
{
    public class Weather
    {
        public float Temperature { get; set; }

        public string Description { get; set; }
    }
}