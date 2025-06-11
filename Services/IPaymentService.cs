using eBazzar.DTO;
using eBazzar.HelperService;
using eBazzar.Model;

namespace eBazzar.Services
{
    public interface IPaymentService
    {
        Task<ServiceResponse<string>> CreateOrderAsync(PaymentRequest request, int userId);
        bool VerifyPayment(PaymentVerificationRequest request);
    }
}
