using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopAPI.Models.Entities;
using ShopAPI.Repositories.Configurations;

namespace ShopAPI.Repositories.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, string>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Register> Registers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> Items { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentWithBillet> PaymentsWithBillet { get; set; }
        public DbSet<PaymentWithCreditCard> PaymentsWithCard { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ConfigureUser();
            builder.ConfigureRegister();
            builder.ConfigureAddress();
            builder.ConfigureOrder();
            builder.ConfigureProduct();
            builder.ConfigureOrderItem();
            builder.ConfigurePayment();

            base.OnModelCreating(builder);
        }
    }
}
