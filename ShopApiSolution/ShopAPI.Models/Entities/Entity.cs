using System;

namespace ShopAPI.Models.Entities
{
    public abstract class Entity
    {
        public string Id = Guid.NewGuid().ToString();

        public DateTime CreatedDate { get; set; }

        public DateTime? LastModifiedDate { get; set; }
    }
}
