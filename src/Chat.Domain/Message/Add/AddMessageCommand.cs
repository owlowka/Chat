using Chat.DataAccess;
using Chat.DataAccess.Entities;
using Chat.Domain.CQRS;

namespace Chat.Domain.Message.Add
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
