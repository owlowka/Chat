using MediatR;

namespace Chat.ApplicationServices.Domain.User.Add
{
    public class AddUserRequest : IRequest<AddUserResponse>
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Username { get; set; }

        public int Age { get; set; }

        public string Password { get; set; }
    }
}
