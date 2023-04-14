using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ShopAPI.Models.Configuration;
using ShopAPI.Models.Entities;
using ShopAPI.Models.ViewModels.Auth;
using ShopAPI.Repositories.Contexts;
using ShopAPI.Services.Interfaces.Auth;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ShopAPI.Services.Implementations.Auth
{
    public class AuthService : IAuthService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly UserDbContext _userDbContext;
        private readonly AppSettings _appSettings;
        private const string DEFAULT_ROLE = "Customer";
        private const string ROLE = "role";

        public AuthService(SignInManager<User> signInManager
                            , UserManager<User> userManager
                            , UserDbContext userDbContext
                            , IOptions<AppSettings> appSettings)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _userDbContext = userDbContext;
            _appSettings = appSettings.Value;
        }

        public async Task<TokenResponseViewModel> RegisterAsync(RegisterRequestViewModel register)
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

        public async Task<TokenResponseViewModel> SignInAsync(LoginRequestViewModel user)
        {
            var result = await _signInManager.PasswordSignInAsync(user.Username, user.Password, false, true);

            if (result.Succeeded)
            {
                return await GenerateTokenAsync(user.Username);
            }

            return null;
        }

        /// <summary>
        /// Generates a new access token and refresh token for the user with the specified username.
        /// </summary>
        private async Task<TokenResponseViewModel> GenerateTokenAsync(string username)
        {
            var user = await _userManager.FindByNameAsync(username);

            var claims = await AddClaimsAsync(user);

            var identityClaims = new ClaimsIdentity(claims);

            var accessToken = CreateAccessToken(identityClaims);

            var refreshToken = CreateRefreshToken();

            await UpdateUserAsync(user, refreshToken);

            return new TokenResponseViewModel(true
                                      , TimeSpan.FromSeconds(_appSettings.HoursToEspireAccessToken).TotalSeconds
                                      , accessToken
                                      , refreshToken
                                      , DateTime.Now.AddHours(_appSettings.HoursToEspireRefreshToken));
        }

        /// <summary>
        /// Creates a new refresh token.
        /// </summary>
        private string CreateRefreshToken()
        {
            return Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Updates the user's refresh token in the database.
        /// </summary>
        private async Task UpdateUserAsync(User user, string refreshToken)
        {
            user.RefreshToken = refreshToken;

            user.RefreshTokenValidity = DateTime.Now.AddHours(_appSettings.HoursToEspireRefreshToken);

            await _userManager.UpdateAsync(user);

            await _userDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Adds additional claims to the user's token.
        /// </summary>       
        private async Task<IList<Claim>> AddClaimsAsync(User user)
        {
            var claims = await _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64));

            userRoles.ToList().ForEach(r => claims.Add(new Claim(ROLE, r)));

            return claims;
        }

        /// <summary>
        /// This method creates an access token for a user by creating a security token using JwtSecurityTokenHandler.
        /// It takes the claims identity of the user as input along with the expiration time for the token and the security key.
        /// Returns the encoded token as a string.
        /// </summary>
        private string CreateAccessToken(ClaimsIdentity identityClaims)
        {
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Issuer,
                Audience = _appSettings.ValidIn,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(_appSettings.HoursToEspireAccessToken),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            });

            var encodedToken = tokenHandler.WriteToken(token);

            return encodedToken;
        }

        public async Task<TokenResponseViewModel> RefreshTokenAsync(RefreshRequestTokenViewModel token)
        {
            var user = await _userManager.FindByNameAsync(token.Username);

            if (user is null) return null;
            
            if(user.RefreshToken.Equals(token.RefreshToken) && user.RefreshTokenValidity >= DateTime.Now)
            {
                return await GenerateTokenAsync(user.UserName);
            }

            return null;
        }
    }
}
