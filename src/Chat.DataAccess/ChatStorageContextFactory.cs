using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Chat.DataAccess
{
    public class ChatStorageContextFactory : IDesignTimeDbContextFactory<ChatStorageContext>
    {
        public ChatStorageContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ChatStorageContext>();

            optionsBuilder.UseSqlite("Data Source = chat.db");

            return new ChatStorageContext(optionsBuilder.Options);
        }
    }
}
