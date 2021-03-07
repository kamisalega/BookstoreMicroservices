using System.Threading.Tasks;
using Bookstore.Services.Payment.Model;

namespace Bookstore.Services.Payment.Services
{
    public interface IExternalGatewayPaymentService
    {
        Task<bool> PerformPayment(PaymentInfo paymentInfo);
    }
}
