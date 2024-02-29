using Chat.Domain.User;

using MediatR;

namespace Chat.Domain.Message.Add
{
    public class AddMessageRequest : IRequest<AddMessageResponse>
    {
        public DateTime CreatedAt { get; set; }

        public string Content { get; set; }

        public required UserModel Sender { get; set; }

    }
}
