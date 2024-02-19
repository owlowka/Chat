using MediatR;

namespace Chat.Domain.Conversation.GetByName
{
    public class GetConversationByNameRequest : IRequest<GetConversationByNameResponse>
    {
        public string Name { get; set; }
    }
}
