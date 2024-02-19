using MediatR;

namespace Chat.Domain.Conversation.GetAll
{
    public class GetConversationRequest : IRequest<GetConversationResponse>
    {
        public Guid Id { get; set; }
    }
}
