using Azure.Core;

using Chat.DataAccess;
using Chat.DataAccess.Entities;
using Chat.Domain.CQRS;

using Microsoft.EntityFrameworkCore;

namespace Chat.Domain.Conversation.GetAll
{
    public class GetConversationsQuery : QueryBase<List<ConversationEntity>>
    {
        public string? UserName { get; set; }

        public override Task<List<ConversationEntity>> Execute(ChatStorageContext context)
        {
            return context.Conversations
                .Where(c => c.Users.Any(u => u.Username == UserName))
                .Include(c => c.Messages).ThenInclude(m => m.Sender)
                //.Include(c => c.Users)
                .ToListAsync();
        }
    }
}
