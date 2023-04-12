using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopAPI.Models.ViewModels.Auth;
using ShopAPI.Services.Interfaces.Auth;
using System.Threading.Tasks;

namespace ShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _userService;

        public AuthController(IAuthService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterViewModel register)
        {
            return Ok(await _userService.RegisterAsync(register));
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignInUserAsync(LoginViewModel user)
        {
            return Ok(await _userService.SignInAsync(user));
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshTokenAsync(RefreshTokenViewModel token)
        {
            return Ok(await _userService.RefreshTokenAsync(token));
        }
    }
}
