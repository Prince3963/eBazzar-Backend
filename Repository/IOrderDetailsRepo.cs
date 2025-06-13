using eBazzar.DTO;
using eBazzar.Model;

namespace eBazzar.Repository
{
    public interface IOrderDetailsRepo
    {
        Task<OrderDetails>? addOrderDetails(OrderDetails orderDetails);

        Task<List<OrderDetails>> getOrderById(int userId);
    }
}
