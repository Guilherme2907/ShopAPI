using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopAPI.Models.Entities;

namespace ShopAPI.Repositories.Contexts
{
    public class UserDbContext : IdentityDbContext<User, Role, string>
    {
        public UserDbContext(DbContextOptions options) : base(options) { }
    }
}
