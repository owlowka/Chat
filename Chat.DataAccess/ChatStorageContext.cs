using Microsoft.EntityFrameworkCore;
using Chat.DataAccess.Entities;

namespace Chat.DataAccess
{
    public class ChatStorageContext : DbContext
    {
        public DbSet<Message> Messages { get; set; }
        public ChatStorageContext(DbContextOptions<ChatStorageContext> options)
            : base(options)
        {
        }

    }
}
