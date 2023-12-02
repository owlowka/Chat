using MediatR;

namespace Chat.ApplicationServices.API.Domain
{
    public class GetUserByUsernameRequest : IRequest<GetUserByUsernameResponse>
    {
        public string Username { get; set; }
    }
}
