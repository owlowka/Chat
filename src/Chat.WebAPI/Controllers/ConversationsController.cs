using Chat.Domain.Conversation.Add;
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
        public Task<ActionResult<GetConversationsResponse>> GetAllConversations([FromQuery] GetConversationsRequest request)
        {
            return HandleRequest<GetConversationsRequest, GetConversationsResponse>(request);
        }

        [HttpGet]
        [Route("{conversationName}")]
        public Task<ActionResult<GetConversationByNameResponse>> GetConversationByName([FromRoute] string conversationName)
        {
            var request = new GetConversationByNameRequest()
            {
                Name = conversationName
            };
            return HandleRequest<GetConversationByNameRequest, GetConversationByNameResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<ActionResult<AddConversationResponse>> AddConversation([FromBody] AddConversationRequest request)
        {
            return HandleRequest<AddConversationRequest, AddConversationResponse>(request);
        }
    }
}
