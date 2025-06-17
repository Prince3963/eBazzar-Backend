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
        private readonly IUserRepo userRepo;
        private readonly IAddressRepo addressRepo;

        public OrderDdetailsServices(IOrderDetailsRepo orderDetails, IProduct product, IUserRepo userRepo, IAddressRepo addressRepo)
        {
            this.orderDetailsRepo = orderDetails;
            this.productRepo = product;
            this.userRepo = userRepo;
            this.addressRepo = addressRepo;
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
            catch (Exception e)
            {
                response.status = false;
                response.message = $"An error occurred: {e.Message}";
                response.data = null;
                return response;
            }

            return response;
        }

        public async Task<ServiceResponse<InvoiceDTO>> getInvoiceData(int user_id, int address_id, string razorpay_order_id)
        {
            try
            {
                var response = new ServiceResponse<InvoiceDTO>();

                var existUser = await userRepo.getUserById(user_id);

                if (existUser == null)
                {
                    response.data = null;
                    response.message = "User noit found!";
                    response.status = false;
                    return response;
                }

                var existAddress = await addressRepo.getAddressByAddressId(address_id);
                if (existAddress == null)
                {
                    response.data = null;
                    response.message = "Address not found for the delairy!";
                    response.status = false;
                    return response;
                }

                var invoiceResult = await orderDetailsRepo.getInvoiceData(razorpay_order_id);

                if (invoiceResult == null)
                {
                    response.data = null;
                    response.message = "RazorPayOrderId not exist!";
                    response.status = false;
                    return response;
                }

                var invoiceData = new InvoiceDTO
                {
                    razorPayOrderId = razorpay_order_id,
                    username = existUser.username,
                    email = existUser.email,
                    amount = invoiceResult.productPrice,
                    //date = invoiceResult.Orders.createdAt,
                    country = existAddress.country,
                    state = existAddress.state,
                    street = existAddress.street,
                    landmark = existAddress.landmark,
                    zipcode = existAddress.zipCode,
                    num = existAddress.number,
                    quntity = invoiceResult.quantity,
                    productImage = invoiceResult.productImage
                };

                response.data = invoiceData;
                response.message = "Data fetched.";
                response.status = true;

                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error in service getInvoice " + ex.Message);
                throw;
            }
        }
    }

}
