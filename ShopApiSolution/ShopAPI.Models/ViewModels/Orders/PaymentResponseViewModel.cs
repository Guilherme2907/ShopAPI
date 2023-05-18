using Microsoft.VisualBasic;
using ShopAPI.Models.Entities;
using ShopAPI.Models.Extensions;
using System;
using System.Reflection;

namespace ShopAPI.Models.ViewModels.Orders
{
    public class PaymentResponseViewModel : PaymentViewModel
    {
        public string Id { get; set; }

        public DateTime PayDate { get; set; }

        public PaymentResponseViewModel()
        {

        }

        public static PaymentResponseViewModel ToModelView(Payment payment)
        {
            return payment switch
            {
                PaymentWithCreditCard => CreatePaymentWithCreditCard(payment as PaymentWithCreditCard),
                PaymentWithBillet => CreatePaymentWithBillet(payment as PaymentWithBillet),
                _ => throw new ArgumentException("Invalid payment type")
            };
        }

        public static PaymentResponseViewModel CreatePaymentWithCreditCard(PaymentWithCreditCard payment)
        {
            return new PaymentResponseViewModel
            {
                Id = payment.Id,
                Installments = payment.Installments,
                PaymentType = payment.GetType().Name.GetPaymentType(),
            };
        }

        public static PaymentResponseViewModel CreatePaymentWithBillet(PaymentWithBillet payment)
        {
            return new PaymentResponseViewModel
            {
                Id = payment.Id,
                DueDate = payment.DueDate,
                PaymentType = payment.GetType().Name.GetPaymentType(),
            };
        }
    }
}