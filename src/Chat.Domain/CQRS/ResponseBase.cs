using Chat.ApplicationServices.ErrorHandling;

namespace Chat.Domain.CQRS
{
    public class ResponseBase<TModel> : ErrorResponseBase
    {
        public TModel? Data { get; set; }
    }
}
