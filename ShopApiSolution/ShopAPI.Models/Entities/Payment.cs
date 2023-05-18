using ShopAPI.Models.Entities.Enums;
using System.Text.Json.Serialization;

namespace ShopAPI.Models.Entities
{
    public abstract class Payment : Entity
    {
        public PaymentStatus PaymentStatus { get; set; }

        [JsonIgnore]
        public virtual Order Order { get; set; }
    }
}
