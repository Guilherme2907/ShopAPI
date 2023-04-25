using System.Collections.Generic;

namespace ShopAPI.Models.Entities
{
    public class Product : Entity
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public IList<OrderItem> Items { get; set; }
    }
}
