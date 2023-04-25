using ShopAPI.Models.Entities;

namespace ShopAPI.Models.ViewModels.Products
{
    public class ProductResponseViewModel : ProductViewModel
    {
        public string Id { get; set; }

        public ProductResponseViewModel(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Price = product.Price;
        }
    }
}
