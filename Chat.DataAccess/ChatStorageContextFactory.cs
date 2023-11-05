using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Chat.DataAccess
{
    public class ChatStorageContextFactory : IDesignTimeDbContextFactory<ChatStorageContext>
    {
        public ChatStorageContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<ChatStorageContext>? optionsBuilder = new DbContextOptionsBuilder<ChatStorageContext>();
            optionsBuilder.UseSqlite( "Data Source = chat.db; Cache = Shared");
            return new ChatStorageContext(optionsBuilder.Options);
        }
    }
}
