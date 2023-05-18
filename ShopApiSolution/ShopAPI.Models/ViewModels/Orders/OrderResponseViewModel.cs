using ShopAPI.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ShopAPI.Models.ViewModels.Orders
{
    public class OrderResponseViewModel : OrderViewModel
    {
        public string Id { get; set; }

        public PaymentResponseViewModel Payment { get; set; }

        public IEnumerable<OrderItemResponseViewModel> Items { get; set; }

        public static OrderResponseViewModel ToModelView(Order order)
        {
            return new OrderResponseViewModel
            {
                Id = order.Id,
                UserId = order.UserId,
                Items = order.Items
                            .ToList()
                            .Select(i => new OrderItemResponseViewModel(i)),
                Payment = PaymentResponseViewModel.ToModelView(order.Payment)
            };
        }
    }
}

