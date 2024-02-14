using MediatR;

namespace Chat.ApplicationServices.Domain.User.GetByUsername
{
    public class GetUserByUsernameRequest : IRequest<GetUserByUsernameResponse>
    {
        public string Username { get; set; }
    }
}
