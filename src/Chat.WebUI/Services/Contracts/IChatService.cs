using Chat.Domain.Message;
using Chat.Domain.User;

namespace Chat.WebUI.Services.Contracts
{
    public interface IChatService
    {
        Task<IEnumerable<MessageModel>> GetMessages();
        Task<UserModel?> GetUserProfile(string useName);
        Task<MessageModel?> SendMessage(string inputMessage);
    }
}
