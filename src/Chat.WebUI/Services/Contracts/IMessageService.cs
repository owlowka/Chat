using Chat.Domain.Message.GetAll;

namespace Chat.WebUI.Services.Contracts
{
    public interface IMessageService
    {
        Task<GetMessagesResponse> GetMessages();

    }
}
