
using Chat.DataAccess.Entities;

using Microsoft.EntityFrameworkCore;

namespace Chat.DataAccess.CQRS.Queries
{
    public class GetUsersQuery : QueryBase<List<UserEntity>>
    {
        public override Task<List<UserEntity>> Execute(ChatStorageContext context)
        {
            return context.Users.ToListAsync();
        }
    }
}
