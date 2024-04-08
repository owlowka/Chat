using Chat.Domain.Conversation;
using Chat.Domain.Message;
using Chat.Domain.User;
using Chat.WebUI.Services.Contracts;

namespace Chat.WebUI.Services
{
    public class StaticChatService : IChatService
    {
        public Task<IEnumerable<ConversationModel>> GetConversations()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MessageModel>> GetMessages()
        {
            return
            [
                new()
                {
                    Content = "test",
                    Sender = new()
                    {
                        Username = "sender"
                    }
                }
            ];
        }

        Task<UserModel?> IChatService.GetUserProfile(string useName)
        {
            throw new NotImplementedException();
        }

        Task IChatService.SendMessage(string inputMessage, string senderName)
        {
            throw new NotImplementedException();
        }
    }
}
