﻿using Chat.Domain.Conversation;
using Chat.Domain.Message;
using Chat.Domain.User;

namespace Chat.WebUI.Services.Contracts
{
    public interface IChatService
    {
        Task<IEnumerable<ConversationModel>> GetConversationsForUserName(string userName);
        Task<IEnumerable<MessageModel>> GetMessages();
        Task<UserModel?> GetUserProfile(string userName);
        Task SendMessage(string inputMessage, string senderName);
    }
}
