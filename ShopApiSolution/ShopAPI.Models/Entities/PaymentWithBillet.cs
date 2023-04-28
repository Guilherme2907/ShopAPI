using System;

namespace ShopAPI.Models.Entities
{
    public class PaymentWithBillet : Payment
    {
        public DateTime DueDate { get; set; }

        public DateTime? PayDate { get; set; }
    }
}
