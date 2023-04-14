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

        /// <summary>
        /// Registers a new user with the specified information.
        /// Creates a new user with the provided information and adds them to the "Customer" role.
        /// </summary>
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterRequestViewModel register)
        {
            return Ok(await _userService.RegisterAsync(register));
        }

        /// <summary>
        /// Signs in a user with the specified credentials and returns a new access token and refresh token.
        /// If the provided credentials are invalid, returns null.
        /// </summary>
        [HttpPost("signin")]
        public async Task<IActionResult> SignInUserAsync(LoginRequestViewModel user)
        {
            return Ok(await _userService.SignInAsync(user));
        }

        /// <summary>
        /// This method refreshes the access token for a user.
        /// It takes the refresh token of the user as input and checks if it is valid by comparing it with the refresh token stored in the database.
        /// If the tokens match and the refresh token has not expired, a new access token is generated and returned.
        /// </summary>
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshTokenAsync(RefreshRequestTokenViewModel token)
        {
            return Ok(await _userService.RefreshTokenAsync(token));
        }

        [Authorize]
        [HttpGet("Teste")]
        public async Task<IActionResult> Teste()
        {
            return Ok("Teste");
        }
    }
}
