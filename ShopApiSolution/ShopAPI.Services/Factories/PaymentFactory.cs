using ShopAPI.Models.Entities;
using ShopAPI.Models.ViewModels.Enums;
using ShopAPI.Models.ViewModels.Orders;
using System;

namespace ShopAPI.Services.Factories
{
    public static class PaymentFactory
    {
        public static Payment GetPayment(this PaymentType paymentType, PaymentRequestViewModel payment)
        {
            return paymentType switch
            {
                PaymentType.PaymentWithBillet => new PaymentWithBillet(payment),
                PaymentType.PaymentWithCreditCard => new PaymentWithCreditCard(payment),
                _ => throw new ArgumentException("Invalid payment type")
            };
        }
    }
}
