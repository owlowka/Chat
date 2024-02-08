using AutoMapper;

using Chat.ApplicationServices.API.Domain;
using Chat.DataAccess.CQRS;
using Chat.DataAccess.CQRS.Queries;
using Chat.ApplicationServices.API.Domain.Models;
using Chat.DataAccess.Entities;

using MediatR;

namespace Chat.ApplicationServices.API.Handlers
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
