
namespace Chat.DataAccess.Entities
{
    public class Conversation : EntityBase
    {
        public required ICollection<Message> Messages { get; init; }
        public required ICollection<User> Users { get; init; }
    }
}
