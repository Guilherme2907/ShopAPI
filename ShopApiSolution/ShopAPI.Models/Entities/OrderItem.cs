using System;

namespace ShopAPI.Models.Entities
{
    public class OrderItem : Entity
    {
        public int Quantity { get; set; }

        public Product Product { get; set; }

        public string ProductId { get; set; }

        public Order Order { get; set; }

        public string OrderId { get; set; }
    }
}
