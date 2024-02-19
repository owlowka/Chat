using Chat.DataAccess;

namespace Chat.Domain.CQRS
{
    public abstract class QueryBase<TResult>
    {
        public abstract Task<TResult> Execute(ChatStorageContext context);
    }
}
