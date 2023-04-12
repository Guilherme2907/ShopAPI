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
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserDbContext _userDbContext;
        private readonly AppSettings _appSettings;

        public AuthService(SignInManager<User> signInManager
                            , UserManager<User> userManager
                            , RoleManager<IdentityRole> roleManager
                            , UserDbContext userDbContext
                            , IOptions<AppSettings> appSettings)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _userDbContext = userDbContext;
            _appSettings = appSettings.Value;
        }

        public async Task<TokenViewModel> RegisterAsync(RegisterViewModel register)
        {
            var user = new User
            {
                UserName = register.Username,
                Email = register.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, register.Password);
            await _userManager.AddToRoleAsync(user, "Customer");

            return null;
        }

        public async Task<TokenViewModel> SignInAsync(LoginViewModel user)
        {
            var result = await _signInManager.PasswordSignInAsync(user.Username, user.Password, false, true);

            if (result.Succeeded)
            {
                return await GenerateTokenAsync(user.Username);
            }

            if (result.IsLockedOut)
            {
                return null;
            }

            return null;
        }

        private async Task<TokenViewModel> GenerateTokenAsync(string username)
        {
            var user = await _userManager.FindByNameAsync(username);

            var claims = await AddClaimsAsync(user);

            var identityClaims = new ClaimsIdentity(claims);

            var accessToken = CreateToken(identityClaims);

            var refreshToken = Guid.NewGuid().ToString();

            user.RefreshToken = refreshToken;

            user.RefreshTokenValidity = DateTime.Now.AddHours(2);

            await _userManager.UpdateAsync(user);

            await _userDbContext.SaveChangesAsync();

            return new TokenViewModel(true
                                      , TimeSpan.FromSeconds(_appSettings.ExpiresIn).TotalSeconds
                                      , accessToken
                                      , refreshToken
                                      , DateTime.Now.AddHours(2));
        }

        private async Task<IList<Claim>> AddClaimsAsync(User user)
        {
            var claims = await _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64));

            userRoles.ToList().ForEach(r => claims.Add(new Claim("role", r)));

            return claims;
        }

        private string CreateToken(ClaimsIdentity identityClaims)
        {
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Issuer,
                Audience = _appSettings.ValidIn,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiresIn),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            });

            var encodedToken = tokenHandler.WriteToken(token);

            return encodedToken;
        }

        public async Task<TokenViewModel> RefreshTokenAsync(RefreshTokenViewModel token)
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
