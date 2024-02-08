
namespace Chat.DataAccess.Entities
{
    public class ConversationEntity : EntityBase
    {
        public string Name { get; set; }
        public required ICollection<MessageEntity> Messages { get; init; }
        public required ICollection<UserEntity> Users { get; init; }
    }
}
