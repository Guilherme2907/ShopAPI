using System.Collections.Generic;

namespace ShopAPI.Models.ViewModels.Orders
{
    public class OrderRequestViewModel : OrderViewModel
    {
        public PaymentRequestViewModel PaymentRequest { get; set; }

        public IList<OrderItemRequestViewModel> Items { get; set; }
    }
}
