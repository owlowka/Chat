
using Chat.DataAccess.Entities;

using Microsoft.EntityFrameworkCore;

namespace Chat.DataAccess.CQRS.Queries
{
    public class GetConversationsQuery : QueryBase<List<ConversationEntity>>
    {
        public override Task<List<ConversationEntity>> Execute(ChatStorageContext context)
        {
            return context.Conversations
                .Include(x => x.Messages)
                .ToListAsync();
        }
    }
}
