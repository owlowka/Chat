using Chat.Domain.Conversation.GetAll;
using Chat.Domain.Conversation.GetByName;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace Chat.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConversationsController : ApiControllerBase
    {
        public ConversationsController(IMediator mediator)
            : base(mediator)
        {
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllConversations([FromQuery] GetConversationsRequest request)
        {
            return HandleRequest<GetConversationsRequest, GetConversationsResponse>(request);
        }

        [HttpGet]
        [Route("{conversationName}")]
        public Task<IActionResult> GetConversationByName([FromRoute] string conversationName)
        {
            var request = new GetConversationByNameRequest()
            {
                Name = conversationName
            };
            return HandleRequest<GetConversationByNameRequest, GetConversationByNameResponse>(request);
        }
    }
}
