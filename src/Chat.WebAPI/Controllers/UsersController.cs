using System.Security.Claims;

using Chat.ApplicationServices.API.Domain;
using Chat.ApplicationServices.API.Domain.Models;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chat.WebAPI.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ApiControllerBase
    {
        private readonly ILogger<UsersController> _logger;

        public UsersController(
            IMediator mediator,
            ILogger<UsersController> logger)
            : base(mediator)
        {
            _logger = logger;
            _logger.LogDebug(1, "Nlog injected into UsersController");
        }

        //[AllowAnonymous]
        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllUsers([FromQuery] GetUsersRequest request)
        {
            _logger.LogInformation("Hello, this is the GetAllUsers!");
            return HandleRequest<GetUsersRequest, GetUsersResponse>(request);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddUser([FromBody] AddUserRequest request)
        {
            return HandleRequest<AddUserRequest, AddUserResponse>(request);
        }

        [HttpGet]
        [Route("{userId}")]
        public Task<IActionResult> GetUserById([FromRoute] Guid userId)
        {

            var request = new GetUserByIdRequest()
            {
                Id = userId
            };

            return HandleRequest<GetUserByIdRequest, GetUserByIdResponse>(request);
        }

        [HttpGet]
        [Route("UserName/{username}")]
        public Task<IActionResult> GetUserByUsername([FromRoute] string username)
        {

            var request = new GetUserByUsernameRequest()
            {
                Username = username
            };

            return HandleRequest<GetUserByUsernameRequest, GetUserByUsernameResponse>(request);
        }

        [HttpGet]
        [Route("me")]
        public Task<IActionResult> GetMyUser()
        {

            var request = new GetUserByUsernameRequest()
            {
                Username = User.FindFirstValue(ClaimTypes.Upn)
            };

            return HandleRequest<GetUserByUsernameRequest, GetUserByUsernameResponse>(request);
        }
    }
}
