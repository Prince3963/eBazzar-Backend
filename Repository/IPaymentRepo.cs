using eBazzar.Model;
using Razorpay.Api;

namespace eBazzar.Repository
{
    public interface IPaymentRepo
    {
        Task<Payments> addPayment(Payments payments);

    }
}
