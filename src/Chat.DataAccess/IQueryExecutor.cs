using Chat.DataAccess.CQRS.Queries;

namespace Chat.DataAccess
{
    public interface IQueryExecutor
    {
        Task<TResult> Execute<TResult>(QueryBase<TResult> query);
    }
}
