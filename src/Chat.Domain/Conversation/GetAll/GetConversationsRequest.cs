using MediatR;

namespace Chat.Domain.Conversation.GetAll
{
    public class GetConversationsRequest : IRequest<GetConversationsResponse>
    {
        public string Name { get; set; }

    }
}
