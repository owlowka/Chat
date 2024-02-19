using Chat.ApplicationServices.ErrorHandling;

namespace Chat.Domain.CQRS
{
    public class ResponseBase<TEntity> : ErrorResponseBase
    {
        public TEntity? Data { get; set; }
    }
}
