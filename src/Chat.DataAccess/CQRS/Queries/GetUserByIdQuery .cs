using Chat.DataAccess.Entities;

using Microsoft.EntityFrameworkCore;

namespace Chat.DataAccess.CQRS.Queries
{
    public class GetUserByIdQuery : QueryBase<UserEntity>
    {
        public Guid Id { get; set; }

        public override async Task<UserEntity> Execute(ChatStorageContext context)
        {

            //var avg = context.Conversations.Select(x => x.Name);

            UserEntity? user = await context.Users.FirstOrDefaultAsync(x => x.Id == Id);

            return user;
        }
    }
}
