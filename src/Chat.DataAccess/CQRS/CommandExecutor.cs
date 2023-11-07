using Chat.DataAccess.CQRS.Commands;

namespace Chat.DataAccess.CQRS
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly ChatStorageContext _context;

        public CommandExecutor(ChatStorageContext context)
        {
            _context = context;
        }

        public Task<TResult> Execute<TParameters, TResult>(CommandBase<TParameters, TResult> command)
        {
            return command.Execute(_context);
        }
    }
}
