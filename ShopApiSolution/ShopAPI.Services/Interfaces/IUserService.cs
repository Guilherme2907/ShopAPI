using ShopAPI.Models.ViewModels.Auth;
using ShopAPI.Models.ViewModels.Register;
using System.Threading.Tasks;

namespace ShopAPI.Services.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Registers a new user with the specified information.
        /// Creates a new user with the provided information and adds them to the "Register" role.
        /// </summary>
        Task<TokenResponseViewModel> RegisterAsync(RegisterLoginRequestViewModel register);
    }
}
