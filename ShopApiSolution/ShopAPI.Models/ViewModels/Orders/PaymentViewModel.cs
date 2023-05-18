using ShopAPI.Models.ViewModels.Enums;
using System;

namespace ShopAPI.Models.ViewModels.Orders
{
    public class PaymentViewModel
    {
        public PaymentType PaymentType { get; set; }

        public DateTime DueDate { get; set; }

        public int Installments { get; set; }
    }
}