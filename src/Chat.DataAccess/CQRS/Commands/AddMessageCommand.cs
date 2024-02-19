using Chat.DataAccess.Entities;

namespace Chat.DataAccess.CQRS.Commands
{
    public class AddMessageCommand : CommandBase<MessageEntity, MessageEntity>
    {
        public override async Task<MessageEntity> Execute(ChatStorageContext context)
        {
            await context.Messages.AddAsync(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
