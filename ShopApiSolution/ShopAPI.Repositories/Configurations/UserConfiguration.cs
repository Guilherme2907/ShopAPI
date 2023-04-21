using Microsoft.EntityFrameworkCore;
using ShopAPI.Models.Entities;

namespace ShopAPI.Repositories.Configurations
{
    public static class UserConfiguration
    {
        public static void ConfigureUser(this ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<User>()
                .ToTable("users")
                .HasKey(u => u.Id);

            modelBuilder
                .Entity<User>()
                .Property(u => u.Id)
                .HasColumnName("Id")
                .IsRequired();

            modelBuilder
               .Entity<User>()
               .HasOne(u => u.Register)
               .WithOne(r => r.User)
               .HasForeignKey<Register>(r => r.UserId);
        }
    }
}
