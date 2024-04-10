using Chat.Domain.User;

namespace Chat.Domain.Message
{
    public class MessageModel
    {
        public required string SenderName { get; set; }

        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public required string Content { get; set; }

    }
}
