using Chat.ApplicationServices.API.Domain;

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

        //[HttpGet]
        //[Route("")]
        //public async Task<IActionResult> GetAllMessages([FromQuery] GetMessagesRequest request)
        //{
        //    var response = await _mediator.Send(request);
        //    return Ok(response);
        //}
    }
}
