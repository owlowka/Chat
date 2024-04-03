using System.Security.Claims;

using Chat.Domain.User.Add;
using Chat.Domain.User.GetAll;
using Chat.Domain.User.GetById;
using Chat.Domain.User.GetByUsername;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace Chat.WebAPI.Controllers
{
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

        [HttpGet]
        [Route("")]
        public Task<ActionResult<GetUsersResponse>> GetAllUsers([FromQuery] GetUsersRequest request)
        {
            _logger.LogInformation("Hello, this is the GetAllUsers!");
            return HandleRequest<GetUsersRequest, GetUsersResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<ActionResult<AddUserResponse>> AddUser([FromBody] AddUserRequest request)
        {
            return HandleRequest<AddUserRequest, AddUserResponse>(request);
        }

        [HttpGet]
        [Route("{userId}")]
        public Task<ActionResult<GetUserByIdResponse>> GetUserById([FromRoute] Guid userId)
        {

            var request = new GetUserByIdRequest()
            {
                Id = userId
            };

            return HandleRequest<GetUserByIdRequest, GetUserByIdResponse>(request);
        }

        [HttpGet]
        [Route("UserName/{username}")]
        public Task<ActionResult<GetUserByUsernameResponse>> GetUserByUsername([FromRoute] string username)
        {

            var request = new GetUserByUsernameRequest()
            {
                Username = username
            };

            return HandleRequest<GetUserByUsernameRequest, GetUserByUsernameResponse>(request);
        }

        [HttpGet]
        [Route("me")]
        public Task<ActionResult<GetUserByUsernameResponse>> GetMyUser()
        {

            var request = new GetUserByUsernameRequest()
            {
                Username = User.FindFirstValue(ClaimTypes.Upn)
            };

            return HandleRequest<GetUserByUsernameRequest, GetUserByUsernameResponse>(request);
        }
    }
}
