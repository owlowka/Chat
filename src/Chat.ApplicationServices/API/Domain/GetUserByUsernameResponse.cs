using Chat.ApplicationServices.API.Domain.Models;

namespace Chat.ApplicationServices.API.Domain
{
    public class GetUserByUsernameResponse : ResponseBase<UserModel>
    {
        public DomainWeather Weather { get; internal set; }
    }
}
