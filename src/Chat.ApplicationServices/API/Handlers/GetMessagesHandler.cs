using Chat.ApplicationServices.API.Domain;
using Chat.ApplicationServices.API.Domain.Models;
using Chat.DataAccess;
using MediatR;

using DbMessage = Chat.DataAccess.Entities.Message;

namespace Chat.ApplicationServices.API.Handlers
{
    public class GetMessagesHandler : IRequestHandler<GetMessagesRequest, GetMessagesResponse>
    {
        private readonly IRepository<DbMessage> _messagesRepository;

        public GetMessagesHandler(IRepository<DbMessage> messagesRepository)
        {
            _messagesRepository = messagesRepository;
        }

        public async Task<GetMessagesResponse> Handle(GetMessagesRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<DbMessage> messages = _messagesRepository.GetAll();
            IEnumerable<Message> domainMessages = messages.Select(x => new Message()
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
