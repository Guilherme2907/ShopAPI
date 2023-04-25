using Microsoft.EntityFrameworkCore;
using ShopAPI.Models.Entities;

namespace ShopAPI.Repositories.Configurations
{
    public static class OrderConfiguration
    {
        public static void ConfigureOrder(this ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Order>()
                .ToTable("orders")
                .HasKey(u => u.Id);

            modelBuilder
                .Entity<Order>()
                .Property(u => u.Id)
                .HasColumnName("Id")
                .IsRequired();

            modelBuilder
               .Entity<Order>()
               .HasOne(o => o.User)
               .WithMany(u => u.Orders)
               .HasForeignKey(o => o.UserId);
        }
    }
}
