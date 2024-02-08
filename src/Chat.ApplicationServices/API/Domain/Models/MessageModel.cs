global using DbMessage = Chat.DataAccess.Entities.MessageEntity;
global using DomainMessage = Chat.ApplicationServices.API.Domain.Models.MessageModel;

namespace Chat.ApplicationServices.API.Domain.Models
{
    public class MessageModel
    {
        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public required string Content { get; set; }

    }
}
