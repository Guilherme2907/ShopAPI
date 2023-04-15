using System;

namespace ShopAPI.Models.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? LastModifiedDate { get; set; }
    }
}
