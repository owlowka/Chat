using Chat.DataAccess;
using Chat.DataAccess.Entities;
using Chat.Domain.CQRS;
using Microsoft.EntityFrameworkCore;



namespace Chat.Domain.Conversation.GetByName
{
    public class GetConversationsByNameQuery : QueryBase<ConversationEntity?>
    {
        public string Name { get; set; }

        public override async Task<ConversationEntity?> Execute(ChatStorageContext context)
        {
            return await context.Conversations
                .SingleOrDefaultAsync(x => x.Name == Name);
        }
    }
}
