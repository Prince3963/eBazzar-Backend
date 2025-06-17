using eBazzar.DTO;
using eBazzar.HelperService;

namespace eBazzar.Services
{
    public interface IOrderDetailsService
    {
        Task<ServiceResponse<string>> addOrderDetails(OrderDetailsDTO orderDetails);
        Task<ServiceResponse<List<OrderDetailsDTO>>> getOrderDetailsById(int user_id);
        Task<ServiceResponse<InvoiceDTO>> getInvoiceData(int user_id, int address_id, string razorpay_order_id);
    }
}
