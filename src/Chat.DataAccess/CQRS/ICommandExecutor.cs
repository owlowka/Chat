using Chat.DataAccess.CQRS.Commands;

namespace Chat.DataAccess.CQRS
{
    public interface ICommandExecutor
    {
        Task<TResult> Execute<TParameters, TResult>(CommandBase<TParameters, TResult> command);

    }
}
