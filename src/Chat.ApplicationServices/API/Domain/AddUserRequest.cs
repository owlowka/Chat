using MediatR;

namespace Chat.ApplicationServices.API.Domain.Models
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
