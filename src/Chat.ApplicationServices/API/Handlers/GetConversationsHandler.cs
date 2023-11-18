
using AutoMapper;

using Chat.ApplicationServices.API.Domain;
using Chat.DataAccess.CQRS;
using Chat.DataAccess.CQRS.Queries;

namespace Chat.ApplicationServices.API.Handlers
{
    public class GetConversationsHandler
    {
        private readonly IMapper _mapper;
        private readonly IQueryExecutor _queryExecutor;

        public GetConversationsHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            _mapper = mapper;
            _queryExecutor = queryExecutor;
        }

        public async Task<GetConversationResponse> Handle(GetConversationRequest request, CancellationToken cancellationToken)
        {
            var query = new GetConversationsQuery();
            List<DbCoversation> conversations = await _queryExecutor.Execute(query);
            List<DomainCoversation> mappedConversation = _mapper.Map<List<DomainCoversation>>(conversations);

            var response = new GetConversationResponse()
            {
                Data = mappedConversation
            };

            return response;

        }
    }
}
