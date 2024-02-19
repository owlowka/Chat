using Chat.DataAccess;

namespace Chat.Domain.CQRS.Database
{
    public class DbQueryExecutor : IQueryExecutor
    {
        private readonly ChatStorageContext _context;

        public DbQueryExecutor(ChatStorageContext context)
        {
            _context = context;
        }
        public Task<TResult> Execute<TResult>(QueryBase<TResult> query)
        {
            return query.Execute(_context);
        }
    }
}
