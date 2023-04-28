using System.Collections.Generic;

namespace ShopAPI.Models.Entities
{
    public class Order : Entity
    {
        public decimal TotalValue { get; set; }

        public User User { get; set; }

        public string UserId { get; set; }

        public Payment Payment { get; set; }

        public string PaymentId { get; set; }

        public IList<OrderItem> Items { get; set; }
    }
}
