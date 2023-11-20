using Chat.ApplicationServices.API.Domain;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace Chat.WebAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UsersController : ApiControllerBase
    {
        private readonly ILogger<UsersController> _logger;

        public UsersController(IMediator mediator, ILogger<UsersController> logger)
            : base(mediator)
        {
            _logger = logger;
            _logger.LogDebug(1, "Nlog injected into UsersController");
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllUsers([FromQuery] GetUsersRequest request)
        {
            _logger.LogInformation("Hello, this is the GetAllUsers!");
            return HandleRequest<GetUsersRequest, GetUsersResponse>(request);
        }

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
    }
}
