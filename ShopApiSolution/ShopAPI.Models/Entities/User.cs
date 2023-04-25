using Microsoft.AspNetCore.Identity;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ShopAPI.Models.Entities
{
    public class User : IdentityUser
    {
        public string RefreshToken { get; set; }

        public DateTime? RefreshTokenValidity { get; set; }

        public Register Register { get; set; }

        public IList<Order> Orders { get; set; }
    }
}
