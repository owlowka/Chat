using MediatR;

namespace Chat.ApplicationServices.Domain.Message.Add
{
    public class AddMessageRequest : IRequest<AddMessageResponse>
    {
        public DateTime CreatedAt { get; set; }

        public string Content { get; set; }

    }
}
