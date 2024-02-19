
namespace Chat.DataAccess.Entities
{
    public class ConversationEntity : EntityBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public required ICollection<MessageEntity> Messages { get; init; }
        public required ICollection<UserEntity> Users { get; init; }
    }
}
