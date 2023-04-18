using Microsoft.EntityFrameworkCore;
using ShopAPI.Models.Entities;

namespace ShopAPI.Repositories.Configurations
{
    public static class RegisterConfiguration
    {
        public static void ConfigureRegister(this ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Register>()
                .ToTable("registers")
                .HasKey(c => c.Id);

            modelBuilder
                .Entity<Register>()
                .Property(c => c.Id)
                .HasColumnName("id")
                .IsRequired();

            modelBuilder
                .Entity<Register>()
                .HasOne(c => c.User)
                .WithOne(u => u.Register)
                .HasForeignKey<User>(u => u.RegisterId);
        }
    }
}
