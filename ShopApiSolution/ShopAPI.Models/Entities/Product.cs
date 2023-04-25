using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ShopAPI.Models.Entities
{
    public class Product : Entity
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        [JsonIgnore]
        public IList<OrderItem> Items { get; set; }
    }
}
