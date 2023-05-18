using ShopAPI.Models.ViewModels.Enums;
using System;

namespace ShopAPI.Models.Extensions
{
    public static class EnumExtensions
    {
        public static PaymentType GetPaymentType(this string paymentName)
        {
            var paymentType = new PaymentType();

            if (!Enum.TryParse(paymentName, out paymentType))
            {
                throw new ArgumentException("Invalid enum for payment type");
            }

            return paymentType;
        }
    }
}
