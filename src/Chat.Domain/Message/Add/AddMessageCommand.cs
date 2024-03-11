using Chat.DataAccess;
using Chat.DataAccess.Entities;
using Chat.Domain.CQRS;

using Microsoft.EntityFrameworkCore;

namespace Chat.Domain.Message.Add
{
    public class AddMessageCommand : CommandBase<MessageEntity, MessageEntity>
    {
        public override async Task<MessageEntity> Execute(ChatStorageContext context)
        {
            Parameter.Sender = await context.Users
                .SingleAsync(user => user.Username == Parameter.Sender.Username);

            await context.Messages.AddAsync(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
