using ShopAPI.Models.ViewModels.Orders;
using System;

namespace ShopAPI.Models.Entities
{
    public class PaymentWithBillet : Payment
    {
        public DateTime DueDate { get; set; }

        public DateTime? PayDate { get; set; }

        public PaymentWithBillet() { }

        public PaymentWithBillet(PaymentRequestViewModel paymentRequest)
        {
            DueDate = paymentRequest.DueDate;
        }
    }
}
