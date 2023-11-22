using Chat.ApplicationServices.Components.OpenWeather.Models;

namespace Chat.ApplicationServices.Components.OpenWeather
{
    public interface IOpenWeatherClient
    {
        Task<OpenWeatherResponse> Get(string city);
    }
}
