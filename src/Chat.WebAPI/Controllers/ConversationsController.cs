using Chat.ApplicationServices.API.Domain;

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
        public Task<IActionResult> GetAllConversations([FromQuery] GetConversationRequest request)
        {
            return HandleRequest<GetConversationRequest, GetConversationResponse>(request);
        }
    }
}
