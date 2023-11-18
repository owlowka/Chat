using AutoMapper;

using Chat.ApplicationServices.API.Domain;
using Chat.ApplicationServices.API.ErrorHandling;
using Chat.DataAccess.CQRS;
using Chat.DataAccess.CQRS.Queries;

using MediatR;

namespace Chat.ApplicationServices.API.Handlers
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdRequest, GetUserByIdResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQueryExecutor _queryExecutor;

        public GetUserByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            _mapper = mapper;
            _queryExecutor = queryExecutor;
        }
        public async Task<GetUserByIdResponse> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetUserByIdQuery()
            {
                Id = request.Id
            };

            var user = await _queryExecutor.Execute(query);
            if (user == null)
            {
                return new GetUserByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var mappedUser = _mapper.Map<DomainUser>(user);
            var response = new GetUserByIdResponse()
            {
                Data = mappedUser
            };
            return response;
        }
    }
}
