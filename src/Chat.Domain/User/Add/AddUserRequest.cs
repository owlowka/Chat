using MediatR;

namespace Chat.Domain.User.Add
{
    public class AddUserRequest : IRequest<AddUserResponse>
    {
        public string Username { get; set; }

        public int Age { get; set; }

        public string Password { get; set; }
    }
}
