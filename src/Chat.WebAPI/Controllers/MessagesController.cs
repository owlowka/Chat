using Chat.Domain.Message.Add;
using Chat.Domain.Message.GetAll;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace Chat.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessagesController : ApiControllerBase
    {
        public MessagesController(IMediator mediator)
            : base(mediator)
        {
        }

        [HttpGet]
        [Route("")]
        public Task<ActionResult<GetMessagesResponse>> GetAllMessages([FromQuery] GetMessagesRequest request)
        {
            return HandleRequest<GetMessagesRequest, GetMessagesResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<ActionResult<AddMessageResponse>> AddMessage([FromBody] AddMessageRequest request)
        {
            return HandleRequest<AddMessageRequest, AddMessageResponse>(request);
        }
    }
}
