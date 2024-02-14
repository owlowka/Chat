using Chat.ApplicationServices.Domain;
using Chat.ApplicationServices.Domain.User;

namespace Chat.ApplicationServices.Domain.User.GetById
{
    public class GetUserByIdResponse : ResponseBase<UserModel>
    {
        public DomainWeather Weather { get; internal set; }
    }
}
