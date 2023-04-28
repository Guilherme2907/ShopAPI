using ShopAPI.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ShopAPI.Models.ViewModels.Orders
{
    public class OrderResponseViewModel : OrderViewModel
    {
        public string Id { get; set; }

        public IEnumerable<OrderItemResponseViewModel> Items { get; set; }

        public OrderResponseViewModel(Order order)
        {
            Id = order.Id;
            UserId = order.UserId;
            Items = order.Items
                            .ToList()
                            .Select(i => new OrderItemResponseViewModel(i));
        }
    }
}
