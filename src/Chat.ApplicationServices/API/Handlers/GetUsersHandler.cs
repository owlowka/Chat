using Chat.ApplicationServices.API.Domain;
using Chat.ApplicationServices.API.Domain.Models;
using Chat.DataAccess;

using MediatR;

using DbUser = Chat.DataAccess.Entities.User;

namespace Chat.ApplicationServices.API.Handlers
{
    public class GetUsersHandler : IRequestHandler<GetUsersRequest, GetUsersResponse>
    {
        private readonly IRepository<DbUser> _userRepository;

        public GetUsersHandler(IRepository<DbUser> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GetUsersResponse> Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {
            //await _userRepository.Insert(new DbUser { Name = "qwe", Age = 22 });

            IEnumerable<DbUser> users = _userRepository.GetAll();
            IEnumerable<User> domainUsers = users.Select(x => new User()
            {
                Id = x.Id,
                Name = x.Name
            });

            var response = new GetUsersResponse()
            {
                Data = domainUsers.ToList()
            };

            return response;

        }
    }
}
