using System.Net.Http.Json;

using Chat.Domain.Conversation;
using Chat.Domain.Conversation.GetAll;
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

        public async Task<IEnumerable<ConversationModel>> GetConversations()
        {
            try
            {
                GetConversationsResponse response =
                    await _httpClient.GetFromJsonAsync<GetConversationsResponse>("Conversations");

                return response?.Data ?? [];
            }
            catch (Exception e)
            {
                //Log exception
                throw;
            }
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
                GetUserByUsernameResponse? response =
                    await _httpClient.GetFromJsonAsync<GetUserByUsernameResponse>($"Users/UserName/{username}");
                return response?.Data;
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

        public async Task SendMessage(string inputMessage, string senderName)
        {

            try
            {
                AddMessageRequest request = new()
                {
                    Sender = senderName,
                    Content = inputMessage,
                    CreatedAt = DateTime.Now
                };

                using HttpResponseMessage response =
                    await _httpClient.PostAsJsonAsync("Messages", request);

                response.EnsureSuccessStatusCode();

                await response.Content.ReadFromJsonAsync<AddMessageResponse>();

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nMessage ---\n{0}", e.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nMessage ---\n{0}", ex.Message);
                Console.WriteLine(
                    "\nHelpLink ---\n{0}", ex.HelpLink);
                Console.WriteLine("\nSource ---\n{0}", ex.Source);
                Console.WriteLine(
                    "\nStackTrace ---\n{0}", ex.StackTrace);
                Console.WriteLine(
                    "\nTargetSite ---\n{0}", ex.TargetSite);
                throw;
            }
        }
    }
}

