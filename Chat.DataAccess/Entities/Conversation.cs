
namespace Chat.DataAccess.Entities
{
    public class Conversation : EntityBase
    {
        public ICollection<Message> Messages { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
