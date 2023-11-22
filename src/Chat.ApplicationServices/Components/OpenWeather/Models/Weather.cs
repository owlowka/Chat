namespace Chat.ApplicationServices.Components.OpenWeather.Models
{
    public class Weather
    {
        public int id { get; set; }
        public required string main { get; set; }
        public required string Description { get; set; }
        public required string icon { get; set; }
    }

}
