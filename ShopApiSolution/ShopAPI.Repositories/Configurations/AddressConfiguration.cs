using Microsoft.EntityFrameworkCore;
using ShopAPI.Models.Entities;

namespace ShopAPI.Repositories.Configurations
{
    public static class AddressConfiguration
    {
        public static void ConfigureAddress(this ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Address>()
                .ToTable("adresses")
                .HasKey(a => a.Id);

            modelBuilder
                .Entity<Address>()
                .Property(a => a.Id)
                .HasColumnName("id")
                .IsRequired();

            modelBuilder
                .Entity<Address>()
                .HasOne(a => a.Register)
                .WithOne(c => c.Address)
                .HasForeignKey<Register>(c => c.AddressId);
        }
    }
}
