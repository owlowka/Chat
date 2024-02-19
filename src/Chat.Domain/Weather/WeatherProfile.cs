using AutoMapper;

using Chat.ApplicationServices.Components.OpenWeather.Models;



namespace Chat.Domain.Weather
{
    public class WeatherProfile : Profile
    {
        public WeatherProfile()
        {
            CreateMap<OpenWeatherResponse, DomainWeather>()
                .ForMember(
                    target => target.Temperature,
                    config => config
                        .MapFrom(source => source.Main.temp))
                .ForMember(
                    target => target.Description,
                    config => config
                        .MapFrom(source => String.Join(
                            " ",
                            source.Weather.Select(w => w.Description))));
        }

    }
}
