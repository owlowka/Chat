
namespace Chat.ApplicationServices.API.Domain
{
    public class ResponseBase<TEntity>
    {
        public TEntity? Data { get; set; }
    }
}
