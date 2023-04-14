using System;

namespace ShopAPI.Models.ViewModels.Auth
{
    public class TokenResponseViewModel
    {
        public bool Authenticated { get; set; }

        public double Expiration { get; set; }

        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }

        public DateTime RefreshTokenValidity { get; set; }

        public TokenResponseViewModel(bool authenticated, double expiration, string accessToken, string refreshToken, DateTime refreshTokenVality)
        {
            Authenticated = authenticated;
            Expiration = expiration;
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            RefreshTokenValidity = refreshTokenVality;
        }
    }
}
