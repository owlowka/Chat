﻿namespace Chat.DataAccess.Entities
{
    public class User : EntityBase
    {
        public ICollection<Conversation> Conversations { get; set; } = new List<Conversation>();

        public required string Name { get; set; }

        public string Surname { get; set; }

        public string Username { get; set; }

        public int Age { get; set; }

        public string Password { get; set; }

    }
}
