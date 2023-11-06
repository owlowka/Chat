namespace Chat.DataAccess.Entities
{
    public class User : EntityBase
    {
        public required ICollection<Conversation> Conversations { get; set; }
        public required string Name { get; set; }
        public int Age { get; set; }
    }
}
