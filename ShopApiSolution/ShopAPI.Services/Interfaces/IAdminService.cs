using ShopAPI.Models.ViewModels.Admin;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopAPI.Services.Interfaces
{
    public interface IAdminService
    {
        /// <summary>
        /// Retrieve all roles.
        /// </summary>
        Task<IEnumerable<RoleResponseViewModel>> GetRolesAsync();

        /// <summary>
        /// Register a new role.
        /// </summary>
        Task RegisterRoleAsync(RoleViewModel role);

        /// <summary>
        /// Register a new role to a specific user.
        /// </summary>
        Task<string> RegisterRoleToUserAsync(UserRoleRequestViewModel userRole);
    }
}
