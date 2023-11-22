namespace Chat.ApplicationServices.Components.OpenWeather.Models
{
    public class Sys
    {
        public int type { get; set; }
        public int id { get; set; }
        public required string country { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }

}
