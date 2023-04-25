using Microsoft.EntityFrameworkCore;
using ShopAPI.Models.Entities;

namespace ShopAPI.Repositories.Configurations
{
    public static class OrderItemConfiguration
    {
        public static void ConfigureOrderItem(this ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<OrderItem>()
                .ToTable("order-items")
                .HasKey(u => u.Id);

            modelBuilder
                .Entity<OrderItem>()
                .Property(u => u.Id)
                .HasColumnName("Id")
                .IsRequired();

            modelBuilder
               .Entity<User>()
               .HasOne(u => u.Register)
               .WithOne(r => r.User)
               .HasForeignKey<Register>(r => r.UserId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(o => o.Order)
                .WithMany(o => o.Items)
                .HasForeignKey(o => o.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderItem>()
                .HasOne(o => o.Product)
                .WithMany(p => p.Items)
                .HasForeignKey(o => o.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
