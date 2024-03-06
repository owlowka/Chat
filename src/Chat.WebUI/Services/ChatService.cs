using System.Net.Http.Json;

using Chat.Domain.Message.Add;
using Chat.Domain.Message.GetAll;
using Chat.Domain.User.GetByUsername;
using Chat.WebUI.Services.Contracts;

namespace Chat.WebUI.Services
{
    public class ChatService : IChatService
    {
        private readonly HttpClient _httpClient;

        public ChatService(HttpClient httpClient)
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

        public async Task<GetUserByUsernameResponse?> GetUserProfile(string username)
        {
            try
            {
                GetUserByUsernameResponse? user =
                    await _httpClient.GetFromJsonAsync<GetUserByUsernameResponse>($"Users/UserName/{username}");
                return user;
            }
            catch (HttpRequestException e)
            {
                return null;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AddMessageResponse?> SendMessage(string inputMessage)
        {

            try
            {
                AddMessageRequest request = new()
                {
                    Sender = "Bob",
                    Content = inputMessage,
                    CreatedAt = DateTime.Now
                };

                using HttpResponseMessage response =
                    await _httpClient.PostAsJsonAsync("Messages", request);

                response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<AddMessageResponse>();

            }
            catch (HttpRequestException e)
            {
                return null;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
