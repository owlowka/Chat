using Chat.DataAccess.Entities;

using Microsoft.EntityFrameworkCore;

namespace Chat.DataAccess.CQRS.Queries
{
    public class GetUserByUsernameQuery : QueryBase<User>
    {
        public Guid Id { get; set; }

        public string Username { get; set; }
        public override async Task<User> Execute(ChatStorageContext context)
        {

            //var avg = context.Conversations.Select(x => x.Name);

            User? user = await context.Users.FirstOrDefaultAsync(x => x.Username == Username);

            return user;
        }
    }
}
