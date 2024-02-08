using AutoMapper;

using Chat.ApplicationServices.API.Domain;
using Chat.DataAccess.CQRS;
using Chat.DataAccess.CQRS.Queries;
using Chat.DataAccess.Entities;
using Chat.ApplicationServices.API.Domain.Models;

using MediatR;


namespace Chat.ApplicationServices.API.Handlers
{
    public class GetUsersHandler : IRequestHandler<GetUsersRequest, GetUsersResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQueryExecutor _queryExecutor;

        public GetUsersHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            _mapper = mapper;
            _queryExecutor = queryExecutor;
        }

        public async Task<GetUsersResponse> Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {
            GetUsersQuery? query = new GetUsersQuery();
            List<UserEntity>? users = await _queryExecutor.Execute(query);
            List<UserModel>? mappedUser = _mapper.Map<List<UserModel>>(users);

            GetUsersResponse? response = new GetUsersResponse()
            {
                Data = mappedUser
            };

            return response;

        }
    }
}
