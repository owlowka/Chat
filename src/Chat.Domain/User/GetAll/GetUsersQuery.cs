using Chat.DataAccess;
using Chat.DataAccess.Entities;
using Chat.Domain.CQRS;

using Microsoft.EntityFrameworkCore;

namespace Chat.Domain.User.GetAll
{
    public class GetUsersQuery : QueryBase<List<UserEntity>>
    {
        public override Task<List<UserEntity>> Execute(ChatStorageContext context)
        {
            return context.Users.ToListAsync();
        }
    }
}
