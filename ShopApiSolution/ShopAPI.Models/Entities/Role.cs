using Microsoft.AspNetCore.Identity;
using System;

namespace ShopAPI.Models.Entities
{
    public class Role : IdentityRole
    {
        public string Description { get; set; }
    }
}
