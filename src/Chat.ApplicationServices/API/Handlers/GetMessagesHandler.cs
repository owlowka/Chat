using Chat.ApplicationServices.API.Domain;
using Chat.ApplicationServices.API.Domain.Models;
using Chat.DataAccess.Entities;
using Chat.DataAccess;

using MediatR;

namespace Chat.ApplicationServices.API.Handlers
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

            GetMessagesResponse? response = new GetMessagesResponse()
            {
                Data = domainMessages.ToList()
            };

            return response;
        }
    }


}
