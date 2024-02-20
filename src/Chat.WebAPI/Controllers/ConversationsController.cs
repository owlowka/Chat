using Chat.Domain.Conversation.Add;
using Chat.Domain.Conversation.GetAll;
using Chat.Domain.Conversation.GetByName;

using MediatR;

using Microsoft.AspNetCore.Authorization;
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

        [AllowAnonymous]
        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddConversation([FromBody] AddConversationRequest request)
        {
            return HandleRequest<AddConversationRequest, AddConversationResponse>(request);
        }
    }
}
