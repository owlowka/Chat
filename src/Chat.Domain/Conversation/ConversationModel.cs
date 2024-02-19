using Chat.Domain.Message;
using Chat.Domain.User;

namespace Chat.Domain.Conversation
{
    public class ConversationModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public required ICollection<MessageModel> Messages { get; init; }
        public required ICollection<UserModel> Users { get; init; }


    }
}
