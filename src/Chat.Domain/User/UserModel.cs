using Chat.Domain.Conversation;

namespace Chat.Domain.User
{
    public class UserModel
    {
        public Guid Id { get; set; }

        public ICollection<ConversationModel> Conversations { get; set; }

        public string Username { get; set; }

        public int Age { get; set; }

        public string Password { get; set; }

        public DomainRole Role { get; set; }
    }
}
