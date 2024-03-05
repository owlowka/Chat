using MediatR;

namespace Chat.Domain.Message.Add
{
    public class AddMessageRequest : IRequest<AddMessageResponse>
    {
        public required DateTime CreatedAt { get; init; }

        public required string Content { get; init; }

        public required string Sender { get; init; }

    }
}
