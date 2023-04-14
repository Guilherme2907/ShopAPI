using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShopAPI.Models.Entities;
using ShopAPI.Models.ViewModels.Admin;
using ShopAPI.Repositories.Contexts;
using ShopAPI.Services.Interfaces.Admin;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopAPI.Services.Implementations.Admin
{
    public class AdminService : IAdminService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly UserDbContext _userDbContext;

        public AdminService(UserManager<User> userManager
                            , RoleManager<Role> roleManager
                            , UserDbContext userDbContext)
        {
            // Constructor method to inject dependencies.
            _userManager = userManager;
            _roleManager = roleManager;
            _userDbContext = userDbContext;
        }

        public async Task<IEnumerable<RoleResponseViewModel>> GetRolesAsync()
        {
            var rolesViewModelList = new List<RoleResponseViewModel>();
            var roles = await _userDbContext.Roles.ToListAsync();
            rolesViewModelList.AddRange(roles.Select(r => new RoleResponseViewModel(r)));
            return rolesViewModelList;
        }

        public async Task RegisterRoleAsync(RoleViewModel role)
        {
            var applicationRole = new Role
            {
                Name = role.Name,
                Description = role.Description,
            };
            await _roleManager.CreateAsync(applicationRole);
        }

        public async Task<string> RegisterRoleToUserAsync(UserRoleRequestViewModel userRole)
        {
            var role = await _roleManager.FindByIdAsync(userRole.RoleId);
            var user = await _userManager.FindByEmailAsync(userRole.Email);

            if (role is null || user is null)
            {
                return null;
            }

            await _userManager.AddToRoleAsync(user, role.Name);
            return user.Email;
        }
    }
}