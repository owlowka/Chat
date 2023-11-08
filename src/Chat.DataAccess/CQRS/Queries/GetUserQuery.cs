using Chat.DataAccess.Entities;

using Microsoft.EntityFrameworkCore;

namespace Chat.DataAccess.CQRS.Queries
{
    public class GetUserQuery : QueryBase<User>
    {
        public Guid Id { get; set; }
        public override async Task<User> Execute(ChatStorageContext context)
        {
            User? user = await context.Users.FirstOrDefaultAsync(x => x.Id == Id);

            return user;
        }
    }
}
