using MediatR;

namespace Chat.ApplicationServices.Domain.Conversation.GetAll
{
    public class GetConversationRequest : IRequest<GetConversationResponse>
    {
        public Guid Id { get; set; }
    }
}
