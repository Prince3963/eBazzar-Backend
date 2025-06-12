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
            try
            {

                var response = new ServiceResponse<string>();
                var existUser = await userRepo.getUserById(userId);
                if (existUser == null)
                {
                    response.data = "0";
                    response.message = "User is not exist";
                    response.status = false;

                    return response;
                }

                var existOrder = new Orders
                {
                    address_id = OrdersDTO.address_id,
                    razorpay_order_id = OrdersDTO.razorpay_order_id,
                    user_id = userId,
                    total_price = OrdersDTO.total_price,
                    createdAt = OrdersDTO.createdAt,
                    status = OrdersDTO.status,
                };

                var newOrder = await orderRepo.addOrder(existOrder);
                if (newOrder != null)
                {
                    response.data = "1";
                    response.message = "Order is Successfull";
                    response.status = true;

                }
                    return response;
            }
            catch(Exception ex)
            {
                Console.WriteLine("ERROR in company service in getAllOrderAdmin Service method: " + ex.Message);
                throw;
            }
        }

        public async Task<List<OrdersDTO>> getAllOrders()
        {
            var result = await orderRepo.getAllOrders();
            return result.Select(o => new OrdersDTO
            {
                address_id = o.address_id,
                username = o.User?.username,
                razorpay_order_id = o.razorpay_order_id,
                createdAt = o.createdAt,
                status = o.status,
                total_price = o.total_price,
            }).ToList();
        }
    }
}
