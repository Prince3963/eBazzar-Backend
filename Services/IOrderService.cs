using eBazzar.DTO;
using eBazzar.HelperService;

namespace eBazzar.Services
{
    public interface IOrderService
    {
        Task<ServiceResponse<string>> addOrder(OrdersDTO getAllOrderDTO, int userId);

        Task<List<OrdersDTO>> getAllOrders();

       
    }
}
