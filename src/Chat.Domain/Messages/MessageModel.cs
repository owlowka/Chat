namespace Chat.ApplicationServices.Domain.Messages
{
    public class MessageModel
    {
        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public required string Content { get; set; }

    }
}
