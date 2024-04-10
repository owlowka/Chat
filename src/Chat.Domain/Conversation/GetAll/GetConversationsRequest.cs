using MediatR;

namespace Chat.Domain.Conversation.GetAll
{
    public class GetConversationsRequest : IRequest<GetConversationsResponse>
    {
        public string UserName { get; set; }

    }
}
