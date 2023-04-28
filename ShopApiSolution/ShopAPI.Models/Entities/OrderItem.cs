using ShopAPI.Models.ViewModels.Orders;
using System;

namespace ShopAPI.Models.Entities
{
    public class OrderItem : Entity
    {
        public int Quantity { get; set; }

        public decimal Value { get; set; }

        public Product Product { get; set; }

        public string ProductId { get; set; }

        public Order Order { get; set; }

        public string OrderId { get; set; }

        public OrderItem()
        {
        }

        public OrderItem(OrderItemRequestViewModel orderItem, string orderId)
        {
            ProductId = orderItem.ProductId;
            OrderId = orderId;
            Quantity = orderItem.Quantity;
        }
    }
}
