using Chat.DataAccess.CQRS.Queries;

namespace Chat.DataAccess.CQRS
{
    public class QueryExecutor : IQueryExecutor
    {
        private readonly ChatStorageContext _context;

        public QueryExecutor(ChatStorageContext context)
        {
            _context = context;
        }
        public Task<TResult> Execute<TResult>(QueryBase<TResult> query)
        {
            return query.Execute(_context);
        }
    }
}
