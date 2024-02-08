global using DbCoversation = Chat.DataAccess.Entities.Conversation;
global using DomainCoversation = Chat.ApplicationServices.API.Domain.Models.Conversation;

namespace Chat.ApplicationServices.API.Domain.Models
{
    public class Conversation
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public required ICollection<MessageModel> Messages { get; init; }
        public required ICollection<UserModel> Users { get; init; }


    }
}
