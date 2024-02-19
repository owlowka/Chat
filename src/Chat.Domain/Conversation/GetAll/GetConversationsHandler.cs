using AutoMapper;

using Chat.DataAccess.Entities;
using Chat.Domain.CQRS;

using MediatR;

namespace Chat.Domain.Conversation.GetAll
{
    public class GetConversationsHandler : IRequestHandler<GetConversationRequest, GetConversationResponse>
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
            List<ConversationEntity> conversations = await _queryExecutor.Execute(query);
            List<ConversationModel> mappedConversation = _mapper.Map<List<ConversationModel>>(conversations);

            var response = new GetConversationResponse()
            {
                Data = mappedConversation
            };

            return response;

        }
    }
}
