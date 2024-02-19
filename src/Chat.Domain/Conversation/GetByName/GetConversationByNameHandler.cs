
using AutoMapper;

using Chat.Domain.CQRS;
using Chat.ApplicationServices.ErrorHandling;


using MediatR;

namespace Chat.Domain.Conversation.GetByName
{
    public class GetConversationByNameHandler : IRequestHandler<GetConversationByNameRequest, GetConversationByNameResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQueryExecutor _queryExecutor;

        public GetConversationByNameHandler(
            IMapper mapper,
            IQueryExecutor queryExecutor
            )
        {
            _mapper = mapper;
            _queryExecutor = queryExecutor;
        }

        public async Task<GetConversationByNameResponse> Handle(GetConversationByNameRequest request, CancellationToken cancellationToken)
        {
            var query = new GetConversationsByNameQuery()
            {
                Name = request.Name
            };

            var conversation = await _queryExecutor.Execute(query);
            if (conversation == null)
            {
                return new GetConversationByNameResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedConversation = _mapper.Map<ConversationModel>(conversation);

            var response = new GetConversationByNameResponse()
            {
                Data = mappedConversation
            };

            return response;
        }
    }
}
