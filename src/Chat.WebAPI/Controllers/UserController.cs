using Chat.DataAccess;
using Chat.DataAccess.Entities;

using Microsoft.AspNetCore.Mvc;

namespace Chat.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IRepository<User> _userRepository;

        public UserController(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route("")]//https://localhost:80/user/
        public IEnumerable<User> GetAllUsers() => _userRepository.GetAll();
    }


}
