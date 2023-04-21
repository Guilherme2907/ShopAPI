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
                .HasColumnName("Id")
                .IsRequired();
        }
    }
}
