using Chat.Domain.Message;
using Chat.Domain.User;

using MediatR;

namespace Chat.Domain.Conversation.Add
{
    public class AddConversationRequest : IRequest<AddConversationResponse>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public required ICollection<MessageModel> Messages { get; init; }
        public required ICollection<UserModel> Users { get; init; }
    }
}
