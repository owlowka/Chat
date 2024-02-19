
using Chat.DataAccess.Entities;

using Microsoft.EntityFrameworkCore;

namespace Chat.DataAccess.CQRS.Queries
{
    public class GetMessagesQuery : QueryBase<List<MessageEntity>>
    {
        public override Task<List<MessageEntity>> Execute(ChatStorageContext context)
        {
            return context.Messages.ToListAsync();
        }
    }
}
