using Chat.DataAccess.Entities;

using Microsoft.EntityFrameworkCore;

namespace Chat.DataAccess.CQRS.Queries
{
    public class GetUserByUsernameQuery : QueryBase<UserEntity>
    {
        public string Username { get; set; }
        public override async Task<UserEntity> Execute(ChatStorageContext context)
        {

            //var avg = context.Conversations.Select(x => x.Name);

            UserEntity? user = await context.Users.FirstOrDefaultAsync(x => x.Username == Username);

            return user;
        }
    }
}
