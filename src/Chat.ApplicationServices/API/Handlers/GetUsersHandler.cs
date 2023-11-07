using AutoMapper;

using Chat.ApplicationServices.API.Domain;
using Chat.ApplicationServices.API.Domain.Models;
using Chat.DataAccess.CQRS;
using Chat.DataAccess.CQRS.Queries;

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
            var query = new GetUsersQuery();
            var users = await _queryExecutor.Execute(query);
            List<User>? mappedUser = _mapper.Map<List<User>>(users);

            var response = new GetUsersResponse()
            {
                Data = mappedUser
            };

            return response;

        }
    }
}
