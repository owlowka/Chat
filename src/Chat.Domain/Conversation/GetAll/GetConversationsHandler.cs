using AutoMapper;

using Chat.DataAccess.Entities;
using Chat.Domain.CQRS;

using MediatR;

namespace Chat.Domain.Conversation.GetAll
{
    public class GetConversationsHandler : IRequestHandler<GetConversationsRequest, GetConversationsResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQueryExecutor _queryExecutor;

        public GetConversationsHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            _mapper = mapper;
            _queryExecutor = queryExecutor;
        }

        public async Task<GetConversationsResponse> Handle(GetConversationsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetConversationsQuery()
            {
                UserName = request.UserName
            };

            List<ConversationEntity> conversations = await _queryExecutor.Execute(query);
            List<ConversationModel> mappedConversations = _mapper.Map<List<ConversationModel>>(conversations);

            var response = new GetConversationsResponse()
            {
                Data = mappedConversations
            };

            return response;

        }
    }
}
