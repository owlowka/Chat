namespace Chat.Domain.Message
{
    public class MessageModel
    {
        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public required string Content { get; set; }

    }
}
