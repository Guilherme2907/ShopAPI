using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopAPI.Models.Entities;
using ShopAPI.Repositories.Configurations;
using System;

namespace ShopAPI.Repositories.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, string>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Register> Registers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ConfigureUser();
            builder.ConfigureRegister();
            builder.ConfigureAddress();

            base.OnModelCreating(builder);
        }
    }
}
