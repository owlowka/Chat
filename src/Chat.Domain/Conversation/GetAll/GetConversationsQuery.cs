using Chat.DataAccess;
using Chat.DataAccess.Entities;
using Chat.Domain.CQRS;

using Microsoft.EntityFrameworkCore;

namespace Chat.Domain.Conversation.GetAll
{
    public class GetConversationQuery : QueryBase<List<ConversationEntity>>
    {
        public override Task<List<ConversationEntity>> Execute(ChatStorageContext context)
        {
            return context.Conversations
                .Include(x => x.Messages)
                .ToListAsync();
        }
    }
}
