using CloudinaryDotNet.Actions;
using eBazzar.DTO;
using eBazzar.HelperService;
using eBazzar.Model;
using eBazzar.Repository;

namespace eBazzar.Services
{
    public class OrderDdetailsServices : IOrderDetailsService
    {
        private readonly IOrderDetailsRepo orderDetailsRepo;
        private readonly IProduct productRepo;

        public OrderDdetailsServices(IOrderDetailsRepo orderDetails, IProduct product)
        {
            this.orderDetailsRepo = orderDetails;
            this.productRepo = product;
        }

        public async Task<ServiceResponse<string>> addOrderDetails(OrderDetailsDTO orderDetails)
        {
            var response = new ServiceResponse<string>();
            try
            {
                var existProduct = await productRepo.getProductById(orderDetails.product_id);
                if (existProduct == null)
                {
                    response.data = "0";
                    response.message = "Product does not exist";
                    response.status = false;
                    return response;
                }

                var newOrderDetails = new OrderDetails
                {
                    order_id = orderDetails.order_id,
                    productId = orderDetails.product_id,
                    productName = orderDetails.product_name,
                    productPrice = orderDetails.final_price,
                    quantity = orderDetails.quantity,
                    productImage = orderDetails.product_image,
                    razorpay_order_id = orderDetails.razorpay_order_id
                };

                await orderDetailsRepo.addOrderDetails(newOrderDetails);

                response.data = "1";
                response.message = "Order Details Added";
                response.status = true;
            }
            catch (Exception ex)
            {
                response.data = "0";
                response.message = "Error in Order Details: " + ex.Message;
                response.status = false;
            }
            return response;
        }

        public async Task<ServiceResponse<List<OrderDetailsDTO>>> getOrderDetailsById(int user_id)
        {
            var response = new ServiceResponse<List<OrderDetailsDTO>>();
            try
            {
                var orderDetails = await orderDetailsRepo.getOrderById(user_id);
                if (orderDetails == null)
                {
                    response.data = null;
                    response.message = "orderDetails is null";
                    response.status = false;

                    return response;
                }

                var orderDetailsList = orderDetails.Select(o => new OrderDetailsDTO
                {
                    
                    final_price = o.productPrice,
                    product_image = o.productImage,
                    product_name = o.productName,
                    quantity = o.quantity,
                    
                }).ToList();

                response.data = orderDetailsList;
                response.message = "OrderDetails fetched";
                response.status = true;
            }
            catch(Exception e)
            {
                response.status = false;
                response.message = $"An error occurred: {e.Message}";
                response.data = null;
                return response;
            }

            return response;
        }
    }
}
