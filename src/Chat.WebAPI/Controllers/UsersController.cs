using Chat.ApplicationServices.API.Domain;
using Chat.DataAccess;
using Chat.DataAccess.Entities;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace Chat.WebAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllUsers([FromQuery] GetUsersRequest request)
        {
            GetUsersResponse? response = await _mediator.Send(request);
            return Ok(response);
        }

        //[HttpGet]
        //[Route("{userId}")]//https://localhost:80/user/userId
        //public User? GetUserById(Guid userID)
        //    => _userRepository.Get(userID);
    }

}
