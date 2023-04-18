using Microsoft.AspNetCore.Identity;
using System;

namespace ShopAPI.Models.Entities
{
    public class User : IdentityUser
    {
        public string RefreshToken { get; set; }

        public DateTime? RefreshTokenValidity { get; set; }

        public string RegisterId { get; set; }

        public Register Register { get; set; }
    }
}
