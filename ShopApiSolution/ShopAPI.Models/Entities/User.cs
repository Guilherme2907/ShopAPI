using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopAPI.Models.Entities
{
    [Table("ApplicationUser")]
    public class User : IdentityUser
    {
        public string RefreshToken { get; set; }

        public DateTime? RefreshTokenValidity { get; set; }
    }
}
