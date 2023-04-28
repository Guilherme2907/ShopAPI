namespace ShopAPI.Models.Entities
{
    public class PaymentWithCreditCard : Payment
    {
        public int Installments { get; set; }
    }
}
