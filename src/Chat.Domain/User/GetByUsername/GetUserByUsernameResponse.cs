namespace Chat.ApplicationServices.Domain.User.GetByUsername
{
    public class GetUserByUsernameResponse : ResponseBase<UserModel>
    {
        public DomainWeather Weather { get; internal set; }
    }
}
