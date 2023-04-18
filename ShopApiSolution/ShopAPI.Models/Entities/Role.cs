using Microsoft.AspNetCore.Identity;

namespace ShopAPI.Models.Entities
{
    public class Role : IdentityRole
    {
        public string Description { get; set; }
    }
}
