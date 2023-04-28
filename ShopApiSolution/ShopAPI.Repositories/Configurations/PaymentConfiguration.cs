using Microsoft.EntityFrameworkCore;
using ShopAPI.Models.Entities;

namespace ShopAPI.Repositories.Configurations
{
    public static class PaymentConfiguration
    {
        public static void ConfigurePayment(this ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Payment>()
                .ToTable("payments")
                .HasKey(u => u.Id);

            modelBuilder
               .Entity<Payment>()
               .HasOne(p => p.Order)
               .WithOne(o => o.Payment)
               .HasForeignKey<Order>(o => o.PaymentId);
        }
    }
}
