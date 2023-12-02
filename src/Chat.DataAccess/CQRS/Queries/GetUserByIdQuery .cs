using Chat.DataAccess.Entities;

using Microsoft.EntityFrameworkCore;

namespace Chat.DataAccess.CQRS.Queries
{
    public class GetUserByIdQuery : QueryBase<User>
    {
        public Guid Id { get; set; }

        public override async Task<User> Execute(ChatStorageContext context)
        {

            //var avg = context.Conversations.Select(x => x.Name);

            User? user = await context.Users.FirstOrDefaultAsync(x => x.Id == Id);

            return user;
        }
    }
}
