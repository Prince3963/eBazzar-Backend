using Razorpay.Api;

namespace eBazzar.Repository
{
    public interface IOrderRepo
    {
        Task<Orders> addOrder(Orders orders);
        Task<List<Orders>> getAllOrders();

    }
}
