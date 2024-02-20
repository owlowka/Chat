using Chat.DataAccess.Entities;

namespace Chat.Domain.Message
{
    public class MessageModel
    {
        public required UserEntity Sender { get; set; }

        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public required string Content { get; set; }

    }
}
