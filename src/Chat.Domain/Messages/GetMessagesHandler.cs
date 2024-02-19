using Chat.DataAccess.Entities;

using MediatR;
using Chat.ApplicationServices.Domain.Messages.GetAll;
using AutoMapper;
using Chat.DataAccess.CQRS;
using Chat.DataAccess.CQRS.Queries;

namespace Chat.ApplicationServices.Domain.Messages
{
    public class GetMessagesHandler : IRequestHandler<GetMessagesRequest, GetMessagesResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQueryExecutor _queryExecutor;

        public GetMessagesHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            _mapper = mapper;
            _queryExecutor = queryExecutor;
        }

        public async Task<GetMessagesResponse> Handle(GetMessagesRequest request, CancellationToken cancellationToken)
        {
            var query = new GetMessagesQuery();
            List<MessageEntity> messages = await _queryExecutor.Execute(query);
            List<MessageModel> mappedMessage = _mapper.Map<List<MessageModel>>(messages);

            var response = new GetMessagesResponse()
            {
                Data = mappedMessage
            };

            return response;
        }
    }


}
