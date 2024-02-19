using Chat.DataAccess;
using Chat.DataAccess.Entities;
using Chat.Domain.CQRS;

using Microsoft.EntityFrameworkCore;

namespace Chat.Domain.User.GetById
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
