using System.Net.Http.Json;

using Chat.Domain.Message;
using Chat.Domain.Message.Add;
using Chat.Domain.Message.GetAll;
using Chat.Domain.User;
using Chat.Domain.User.GetByUsername;
using Chat.WebUI.Services.Contracts;

namespace Chat.WebUI.Services
{
    public class HttpChatService : IChatService
    {
        private readonly HttpClient _httpClient;

        public HttpChatService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<MessageModel>> GetMessages()
        {
            try
            {
                GetMessagesResponse response =
                    await _httpClient.GetFromJsonAsync<GetMessagesResponse>("Messages");

                return response?.Data ?? [];
            }
            catch (Exception e)
            {
                //Log exception
                throw;
            }
        }

        public async Task<UserModel?> GetUserProfile(string username)
        {
            try
            {
                GetUserByUsernameResponse? user =
                    await _httpClient.GetFromJsonAsync<GetUserByUsernameResponse>($"Users/UserName/{username}");
                return user?.Data;
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

        public async Task<MessageModel?> SendMessage(string inputMessage)
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

                return await response.Content.ReadFromJsonAsync<MessageModel>();

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
