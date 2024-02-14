using Chat.ApplicationServices.Domain;
using Chat.ApplicationServices.Domain.User;

namespace Chat.ApplicationServices.Domain.User.GetByUsername
{
    public class GetUserByUsernameResponse : ResponseBase<UserModel>
    {
        public DomainWeather Weather { get; internal set; }
    }
}
