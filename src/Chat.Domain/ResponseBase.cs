using Chat.ApplicationServices.ErrorHandling;

namespace Chat.ApplicationServices.Domain
{
    public class ResponseBase<TEntity> : ErrorResponseBase
    {
        public TEntity? Data { get; set; }
    }
}
