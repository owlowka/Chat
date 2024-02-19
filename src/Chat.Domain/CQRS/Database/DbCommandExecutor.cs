using Chat.DataAccess;

namespace Chat.Domain.CQRS.Database
{
    public class DbCommandExecutor : ICommandExecutor
    {
        private readonly ChatStorageContext _context;

        public DbCommandExecutor(ChatStorageContext context)
        {
            _context = context;
        }

        public Task<TResult> Execute<TParameters, TResult>(CommandBase<TParameters, TResult> command)
        {
            return command.Execute(_context);
        }
    }
}
