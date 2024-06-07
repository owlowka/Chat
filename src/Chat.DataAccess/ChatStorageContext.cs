using Chat.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Chat.DataAccess
{
    public class ChatStorageContext : DbContext// : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
    {
        public ChatStorageContext(DbContextOptions<ChatStorageContext> options)
            : base(options)
        {
            //new ChatStorageContext(default);
        }

        public DbSet<MessageEntity> Messages { get; set; }

        public DbSet<ConversationEntity> Conversations { get; set; }

        public DbSet<UserEntity> Users { get; set; }
    }
}
