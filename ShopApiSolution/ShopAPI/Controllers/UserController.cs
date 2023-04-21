using Microsoft.AspNetCore.Mvc;
using ShopAPI.Models.ViewModels.Auth;
using ShopAPI.Models.ViewModels.Register;
using ShopAPI.Services.Interfaces;
using System.Threading.Tasks;

namespace ShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Registers a new user with the specified information.
        /// Creates a new user with the provided information and adds them to the "Customer" role.
        /// </summary>
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterLoginRequestViewModel register)
        {
            return Ok(await _userService.RegisterAsync(register));
        }
    }
}
