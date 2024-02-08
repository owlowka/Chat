namespace Chat.DataAccess.Entities
{
    public class UserEntity : EntityBase
    {
        public ICollection<ConversationEntity> Conversations { get; set; } = new List<ConversationEntity>();

        public required string Name { get; set; }

        public string Surname { get; set; }

        public string Username { get; set; }

        public int Age { get; set; }

        public string Password { get; set; }

        public Role Role { get; set; }

    }
}
