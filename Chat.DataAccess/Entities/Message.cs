using System.ComponentModel.DataAnnotations;

namespace Chat.DataAccess.Entities
{
    public class Message : EntityBase
    {
        public User Sender { get; set; }

        public Conversation Conversation { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
