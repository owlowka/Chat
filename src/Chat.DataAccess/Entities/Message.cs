using System.ComponentModel.DataAnnotations;

namespace Chat.DataAccess.Entities
{
    public class Message : EntityBase
    {
        public required User Sender { get; set; }

        public required Conversation Conversation { get; set; }

        [Required]
        [MaxLength(1000)]
        public required string Content { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
