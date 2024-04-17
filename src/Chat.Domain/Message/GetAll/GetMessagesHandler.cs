using Chat.DataAccess.Entities;

using MediatR;
using AutoMapper;
using Chat.Domain.CQRS;
using Chat.ApplicationServices.ErrorHandling;

namespace Chat.Domain.Message.GetAll
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
            if (messages == null)
            {
                return new GetMessagesResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            List<MessageModel> mappedMessage = _mapper.Map<List<MessageModel>>(messages);

            var response = new GetMessagesResponse()
            {
                Data = mappedMessage
            };

            return response;
        }
    }


}
