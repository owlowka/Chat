using Chat.DataAccess;
using Chat.DataAccess.Entities;
using Chat.Domain.CQRS;

namespace Chat.Domain.Conversation.Add
{
    public class AddConversationCommand : CommandBase<ConversationEntity, ConversationEntity>
    {
        public override async Task<ConversationEntity> Execute(ChatStorageContext context)
        {
            await context.Conversations.AddAsync(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
