using ShopAPI.Models.ViewModels.Auth;
using System.Threading.Tasks;

namespace ShopAPI.Services.Interfaces.Auth
{
    public interface IAuthService
    {
        /// <summary>
        /// Registers a new user with the specified information.
        /// Creates a new user with the provided information and adds them to the "Customer" role.
        /// </summary>
        Task<TokenResponseViewModel> RegisterAsync(RegisterRequestViewModel register);

        /// <summary>
        /// Signs in a user with the specified credentials and returns a new access token and refresh token.
        /// If the provided credentials are invalid, returns null.
        /// </summary>
        Task<TokenResponseViewModel> SignInAsync(LoginRequestViewModel user);

        /// <summary>
        /// This method refreshes the access token for a user.
        /// It takes the refresh token of the user as input and checks if it is valid by comparing it with the refresh token stored in the database.
        /// If the tokens match and the refresh token has not expired, a new access token is generated and returned.
        /// </summary>
        Task<TokenResponseViewModel> RefreshTokenAsync(RefreshRequestTokenViewModel token);
    }
}
