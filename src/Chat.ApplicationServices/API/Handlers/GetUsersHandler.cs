using AutoMapper;

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
        private readonly IMapper _mapper;

        public GetUsersHandler(IRepository<DbUser> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<GetUsersResponse> Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {
            //await _userRepository.Insert(new DbUser { Name = "qwe", Age = 22 });

            IEnumerable<DbUser> users = await _userRepository.GetAll();

            List<User>? mappedUser = _mapper.Map<List<User>>(users);

            var response = new GetUsersResponse()
            {
                Data = mappedUser
            };

            return response;

        }
    }
}
