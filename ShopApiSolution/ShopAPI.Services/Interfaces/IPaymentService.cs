using ShopAPI.Models.Entities;
using System.Threading.Tasks;

namespace ShopAPI.Services.Interfaces
{
    public interface IPaymentService
    {
        Task ExecutePayment(Payment payment);
    }
}
