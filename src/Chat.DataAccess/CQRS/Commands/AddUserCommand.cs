using Chat.DataAccess.Entities;

namespace Chat.DataAccess.CQRS.Commands
{
    public class AddUserCommand : CommandBase<User, User>
    {
        public override async Task<User> Execute(ChatStorageContext context)
        {
            await context.Users.AddAsync(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
