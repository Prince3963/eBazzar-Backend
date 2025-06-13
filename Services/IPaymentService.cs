using eBazzar.DTO;
using eBazzar.HelperService;
using eBazzar.Model;

namespace eBazzar.Services
{
    public interface IPaymentService
    {
        Task<ServiceResponse<string>> CreateOrderAsync(PaymentRequest request, int userId);
        Task<bool> VerifyPayment(PaymentVerificationRequest request, int userId);
    }
}
