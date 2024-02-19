using Chat.DataAccess;
using Chat.DataAccess.Entities;
using Chat.Domain.CQRS;

using Microsoft.EntityFrameworkCore;

namespace Chat.Domain.Message.GetAll
{
    public class GetMessagesQuery : QueryBase<List<MessageEntity>>
    {
        public override Task<List<MessageEntity>> Execute(ChatStorageContext context)
        {
            return context.Messages.ToListAsync();
        }
    }
}
