using Chat.DataAccess.Entities;

namespace Chat.DataAccess.CQRS.Commands
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
