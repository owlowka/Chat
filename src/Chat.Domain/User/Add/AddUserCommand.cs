using Chat.DataAccess;
using Chat.DataAccess.Entities;
using Chat.Domain.CQRS;

namespace Chat.Domain.User.Add
{
    public class AddUserCommand : CommandBase<UserEntity, UserEntity>
    {
        public override async Task<UserEntity> Execute(ChatStorageContext context)
        {
            await context.Users.AddAsync(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
