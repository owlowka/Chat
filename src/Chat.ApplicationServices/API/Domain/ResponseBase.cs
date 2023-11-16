
namespace Chat.ApplicationServices.API.Domain
{
    public class ResponseBase<TEntity> : ErrorResponseBase
    {
        public TEntity? Data { get; set; }
    }
}
