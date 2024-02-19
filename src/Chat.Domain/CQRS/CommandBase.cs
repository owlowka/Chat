using Chat.DataAccess;

namespace Chat.Domain.CQRS
{
    public abstract class CommandBase<TParameter, TResult>
    {
        public TParameter Parameter { get; set; }

        public abstract Task<TResult> Execute(ChatStorageContext context);
    }
}
