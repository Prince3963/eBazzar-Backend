using eBazzar.Model;

namespace eBazzar.Repository
{
    public interface IPaymentRepo
    {
        Task<Payments> addPayment(Payments payments);
    }
}
