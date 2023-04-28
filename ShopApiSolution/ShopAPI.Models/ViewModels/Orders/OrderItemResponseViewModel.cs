using ShopAPI.Models.Entities;
using ShopAPI.Models.ViewModels.Products;
using System.Text.Json.Serialization;

namespace ShopAPI.Models.ViewModels.Orders
{
    public class OrderItemResponseViewModel: OrderItemViewModel
    {
        public string Id { get; set; }

        public ProductResponseViewModel Product { get; set; }

        public OrderItemResponseViewModel(OrderItem item)
        {
            Id = item.Id;
            Quantity = item.Quantity;
            Product = new ProductResponseViewModel(item.Product);
        }
    }
}
