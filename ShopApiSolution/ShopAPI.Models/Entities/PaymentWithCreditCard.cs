using ShopAPI.Models.ViewModels.Orders;

namespace ShopAPI.Models.Entities
{
    public class PaymentWithCreditCard : Payment
    {
        public int Installments { get; set; }

        public PaymentWithCreditCard() { }

        public PaymentWithCreditCard(PaymentRequestViewModel paymentRequest)
        {
            Installments = paymentRequest.Installments;
        }
    }
}
