
using Chat.DataAccess.Entities;

using Microsoft.EntityFrameworkCore;

namespace Chat.DataAccess.CQRS.Queries
{
    public class GetConversationsQuery : QueryBase<List<Conversation>>
    {
        public override Task<List<Conversation>> Execute(ChatStorageContext context)
        {
            return context.Conversations
                .Include(x => x.Messages)
                .ToListAsync();
        }
    }
}
