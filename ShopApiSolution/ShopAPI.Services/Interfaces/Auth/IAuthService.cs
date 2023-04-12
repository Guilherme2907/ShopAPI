using ShopAPI.Models.ViewModels.Auth;
using System.Threading.Tasks;

namespace ShopAPI.Services.Interfaces.Auth
{
    public interface IAuthService
    {
        Task<TokenViewModel> RegisterAsync(RegisterViewModel register);

        Task<TokenViewModel> SignInAsync(LoginViewModel user);

        Task<TokenViewModel> RefreshTokenAsync(RefreshTokenViewModel token);
    }
}
