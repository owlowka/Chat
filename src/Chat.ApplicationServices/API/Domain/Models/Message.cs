

namespace Chat.ApplicationServices.API.Domain.Models
{
    public class Message
    {
        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public required string Content { get; set; }

    }
}
