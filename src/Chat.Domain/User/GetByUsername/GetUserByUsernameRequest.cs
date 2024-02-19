using MediatR;

namespace Chat.Domain.User.GetByUsername
{
    public class GetUserByUsernameRequest : IRequest<GetUserByUsernameResponse>
    {
        public string Username { get; set; }
    }
}
