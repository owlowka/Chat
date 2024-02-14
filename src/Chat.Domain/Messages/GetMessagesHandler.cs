using Chat.DataAccess.Entities;
using Chat.DataAccess;

using MediatR;
using Chat.ApplicationServices.Domain.Messages.GetAll;

namespace Chat.ApplicationServices.Domain.Messages
{
    public class GetMessagesHandler : IRequestHandler<GetMessagesRequest, GetMessagesResponse>
    {
        private readonly IRepository<MessageEntity> _messagesRepository;

        public GetMessagesHandler(IRepository<MessageEntity> messagesRepository)
        {
            _messagesRepository = messagesRepository;
        }

        public async Task<GetMessagesResponse> Handle(GetMessagesRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<MessageEntity> messages = await _messagesRepository.GetAll();
            IEnumerable<MessageModel> domainMessages = messages.Select(x => new MessageModel()
            {
                Id = x.Id,
                CreatedAt = x.CreatedAt,
                Content = x.Content
            });

            var response = new GetMessagesResponse()
            {
                Data = domainMessages.ToList()
            };

            return response;
        }
    }


}
