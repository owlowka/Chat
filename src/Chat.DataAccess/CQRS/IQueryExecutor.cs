using Chat.DataAccess.CQRS.Queries;

namespace Chat.DataAccess.CQRS
{
    public interface IQueryExecutor
    {
        Task<TResult> Execute<TResult>(QueryBase<TResult> query);
    }
}
