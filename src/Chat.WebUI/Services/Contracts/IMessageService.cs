using Chat.Domain.Message.GetAll;
using Chat.Domain.User.GetByUsername;

namespace Chat.WebUI.Services.Contracts
{
    public interface IMessageService
    {
        Task<GetMessagesResponse> GetMessages();
        Task<GetUserByUsernameResponse> GetUserProfile(string useName);
    }
}
