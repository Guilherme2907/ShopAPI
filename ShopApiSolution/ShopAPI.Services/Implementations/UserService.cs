using Microsoft.AspNetCore.Identity;
using ShopAPI.Models.Entities;
using ShopAPI.Models.ViewModels.Auth;
using ShopAPI.Services.Interfaces;
using System.Threading.Tasks;

namespace ShopAPI.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;

        private const string DEFAULT_ROLE = "Customer";

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<TokenResponseViewModel> RegisterAsync(RegisterLoginRequestViewModel register)
        {
            var user = new User
            {
                UserName = register.Username,
                Email = register.Email,
                EmailConfirmed = true
            };

            await _userManager.CreateAsync(user, register.Password);
            await _userManager.AddToRoleAsync(user, DEFAULT_ROLE);

            return null;
        }
    }
}
