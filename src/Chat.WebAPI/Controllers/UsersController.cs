using Chat.ApplicationServices.API.Domain;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace Chat.WebAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UsersController : ApiControllerBase
    {
        public UsersController(IMediator mediator)
            : base(mediator)
        {
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllUsers([FromQuery] GetUsersRequest request)
        {
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
