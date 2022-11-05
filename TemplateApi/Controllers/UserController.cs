using Contracts.DTO.User;
using Contracts.Interfaces.Services;
using Contracts.TransactionObjects.Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Contracts.Utils;

namespace TemplateApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) => _userService = userService;

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserDto registerRequest)
        {
            var result = await _userService.Register(registerRequest);
            return Ok(result);
        }

        [HttpPut("updateUser")]
        public async Task<IActionResult> Update(UserDto user)
        {
            var result = await _userService.UpdateUser(user);
            return Ok(result);
        }

        [HttpPut("deleteUser")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userService.DeleteUser(id);
            return Ok(result);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginRequestDto loginRequest)
        {
            var auth = await _userService.Login(loginRequest);
            return Ok(auth);
        }

        [HttpGet("getUser/{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var result = await _userService.GetUserById(id);
            return Ok(result);
        }
        
        [HttpDelete("getLoggedUser")]
        public async Task<IActionResult> GetLoggedUser()
        {
            var id = User.GetUserId();
            var result = await _userService.GetUserById(id);

            return Ok(result);
        }

    }
}
