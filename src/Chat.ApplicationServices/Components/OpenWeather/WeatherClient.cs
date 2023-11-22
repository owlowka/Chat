using Chat.ApplicationServices.Components.OpenWeather.Models;

using Newtonsoft.Json;

using RestSharp;


namespace Chat.ApplicationServices.Components.OpenWeather
{
    public class WeatherClient : IOpenWeatherClient
    {
        private readonly IRestClient _restClient;

        public WeatherClient(IRestClient restClient)
        {
            _restClient = restClient;
        }
        public async Task<OpenWeatherResponse> Get(string city)
        {
            var request = new RestRequest("data/2.5/weather", Method.Get);

            request.AddParameter("q", city);

            RestResponse? queryResult = await _restClient
                .ExecuteAsync(request);

            OpenWeatherResponse? weather = JsonConvert
                .DeserializeObject<OpenWeatherResponse>(queryResult.Content);
            return weather;
        }
    }
}
