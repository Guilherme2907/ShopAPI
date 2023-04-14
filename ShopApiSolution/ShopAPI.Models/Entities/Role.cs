using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopAPI.Models.Entities
{
    public class Role : IdentityRole
    {
        public string Description { get; set; }
    }
}
