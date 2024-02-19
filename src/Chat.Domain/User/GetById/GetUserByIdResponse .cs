using Chat.Domain.CQRS;

namespace Chat.Domain.User.GetById
{
    public class GetUserByIdResponse : ResponseBase<UserModel>
    {
        public DomainWeather Weather { get; internal set; }
    }
}
