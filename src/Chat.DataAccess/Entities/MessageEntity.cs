using System.ComponentModel.DataAnnotations;

namespace Chat.DataAccess.Entities
{
    public class MessageEntity : EntityBase
    {
        public required UserEntity Sender { get; set; }

        public required ConversationEntity Conversation { get; set; }

        [Required]
        [MaxLength(1000)]
        public required string Content { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
