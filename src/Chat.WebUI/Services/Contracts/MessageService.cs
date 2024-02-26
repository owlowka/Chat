using System.Net.Http.Json;

using Chat.Domain.Message.GetAll;

namespace Chat.WebUI.Services.Contracts
{
    public class MessageService : IMessageService
    {
        private readonly HttpClient _httpClient;

        public MessageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetMessagesResponse> GetMessages()
        {
            try
            {
                GetMessagesResponse? messages =
                    await _httpClient.GetFromJsonAsync<GetMessagesResponse>("Messages");
                return messages;
            }
            catch (Exception e)
            {
                //Log exception
                throw;
            }


        }
    }
}
