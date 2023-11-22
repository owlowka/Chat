
namespace Chat.ApplicationServices.Components.OpenWeather.Models
{
    public class OpenWeatherResponse
    {
        public required Coord Coord { get; set; }
        public required Weather[] Weather { get; set; }
        public required string _base { get; set; }
        public required Main Main { get; set; }
        public int visibility { get; set; }
        public required Wind wind { get; set; }
        public required Rain rain { get; set; }
        public required Clouds clouds { get; set; }
        public int dt { get; set; }
        public required Sys sys { get; set; }
        public int timezone { get; set; }
        public int id { get; set; }
        public required string Name { get; set; }
        public int cod { get; set; }
    }

}
