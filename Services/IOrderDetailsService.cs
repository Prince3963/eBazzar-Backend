using eBazzar.DTO;
using eBazzar.HelperService;

namespace eBazzar.Services
{
    public interface IOrderDetailsService
    {
        Task<ServiceResponse<string>> addOrderDetails(OrderDetailsDTO orderDetails);
    }
}
