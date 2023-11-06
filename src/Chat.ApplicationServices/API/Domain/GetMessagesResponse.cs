
using Chat.ApplicationServices.API.Domain.Models;

using MediatR;

namespace Chat.ApplicationServices.API.Domain
{
    public class GetMessagesResponse : ResponseBase<List<Message>>
    {

    }
}
