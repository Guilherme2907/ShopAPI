using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopAPI.Models.ViewModels.Admin;
using ShopAPI.Services.Interfaces;
using System.Threading.Tasks;

namespace ShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        /// <summary>
        /// Retrieve all roles.
        /// </summary>
        [Authorize(Roles = "Admin")]
        [HttpGet("roles")]
        public async Task<IActionResult> GetRolesAsync()
        {
            return Ok(await _adminService.GetRolesAsync());
        }

        /// <summary>
        /// Register a new role.
        /// </summary>
        [Authorize(Roles = "Admin")]
        [HttpPost("register-role")]
        public async Task<IActionResult> RegisterRoleAsync(RoleRequestViewModel role)
        {
            await _adminService.RegisterRoleAsync(role);

            return Ok();
        }

        /// <summary>
        /// Register a new role to a specific user.
        /// </summary>
        [Authorize(Roles = "Admin")]
        [HttpPost("register-user-role")]
        public async Task<IActionResult> RegisterUserRoleAsync(UserRoleRequestViewModel userRole)
        {
            return Ok(await _adminService.RegisterRoleToUserAsync(userRole));
        }
    }
}
