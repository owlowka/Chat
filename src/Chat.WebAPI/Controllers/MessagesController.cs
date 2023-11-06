using Chat.ApplicationServices.API.Domain;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace Chat.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessagesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MessagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllMessages([FromQuery] GetMessagesRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
