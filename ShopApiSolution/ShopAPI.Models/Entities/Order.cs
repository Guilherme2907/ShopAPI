using System.Collections.Generic;

namespace ShopAPI.Models.Entities
{
    public class Order : Entity
    {
        public User User { get; set; }

        public string UserId { get; set; }

        public IList<OrderItem> Items { get; set; }
    }
}
