using Business.Interface;
using Business.Services;
using Microsoft.AspNetCore.Mvc;
using Models.Mapper.Request;
using Models.Mapper.Response;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Authorize")]
        public IActionResult Authorize([FromBody] LoginPost loginPost)
        {
            return Execute(() => _userService.Login(loginPost).Result);
        }
    }
}
