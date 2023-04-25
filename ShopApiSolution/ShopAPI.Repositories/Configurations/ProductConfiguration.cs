using Microsoft.EntityFrameworkCore;
using ShopAPI.Models.Entities;

namespace ShopAPI.Repositories.Configurations
{
    public static class ProductConfiguration
    {
        public static void ConfigureProduct(this ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Product>()
                .ToTable("products")
                .HasKey(u => u.Id);

            modelBuilder
                .Entity<Product>()
                .Property(u => u.Id)
                .HasColumnName("Id")
                .IsRequired();
        }
    }
}
