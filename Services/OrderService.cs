using eBazzar.DTO;
using eBazzar.HelperService;
using eBazzar.Repository;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace eBazzar.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepo orderRepo;
        private readonly IUserRepo userRepo;

        public OrderService(IOrderRepo orderRepo, IUserRepo userRepo)
        {
            this.orderRepo = orderRepo;
            this.userRepo = userRepo;
        }

        public async Task<ServiceResponse<string>> addOrder(OrdersDTO OrdersDTO, int userId)
        {
            var response = new ServiceResponse<string>();

            try
            {
                var existUser = await userRepo.getUserById(userId);
                if (existUser == null)
                {
                    response.message = "User not found";
                    response.status = false;
                    return response;
                }

                //// Optional: check if order already exists
                //var alreadyExist = await orderRepo.getOrderByRazorpayOrderId(OrdersDTO.razorpay_order_id);
                //if (alreadyExist != null)
                //{
                //    response.message = "Order already exists";
                //    response.status = false;
                //    return response;
                //}

                var newOrder = new Orders
                {
                    address_id = OrdersDTO.address_id,
                    razorpay_order_id = OrdersDTO.razorpay_order_id,
                    user_id = userId,
                    total_price = OrdersDTO.total_price,
                    createdAt = DateTime.Now,
                    status = OrdersDTO.status ?? "Pending"
                };

                var insertedOrder = await orderRepo.addOrder(newOrder);

                response.data = insertedOrder.order_id.ToString();
                response.message = "Order successfully created";
                response.status = true;
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine("AddOrder error: " + ex.Message);
                throw;
            }
        }

        public async Task<ServiceResponse<List<OrdersDTO>>> getAllOrders()
        {
            try
            {
                var response = new ServiceResponse<List<OrdersDTO>>();

                var data = await orderRepo.getAllOrders();

                if (data == null)
                {
                    response.data = null;
                    response.message = "null";
                    response.status = false;
                    return response;
                }

                var result = data.Select(o => new OrdersDTO
                {
                    address_id = o.address_id,
                    username = o.User?.username,
                    razorpay_order_id = o.razorpay_order_id,
                    createdAt = o.createdAt,
                    status = o.status,
                    total_price = o.total_price,
                }).ToList();

                response.data = result;
                response.message = "Data fecthed.";
                response.status = true;
                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
