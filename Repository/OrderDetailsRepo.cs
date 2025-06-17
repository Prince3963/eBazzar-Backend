using eBazzar.DBcontext;
using eBazzar.DTO;
using eBazzar.Model;
using Microsoft.EntityFrameworkCore;

namespace eBazzar.Repository
{
    public class OrderDetailsRepo : IOrderDetailsRepo
    {
        private readonly AppDBContext dBContext;
        public OrderDetailsRepo(AppDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task<OrderDetails> addOrderDetails(OrderDetails orderDetails)
        {
            await dBContext.orderDetails.AddAsync(orderDetails);
            await dBContext.SaveChangesAsync();
            return orderDetails;
        }

        public async Task<List<OrderDetails>> getOrderById(int userId)
        {
            var orderDetailsList = await dBContext.orderDetails
                .Include(od => od.Orders)
                .ThenInclude(o => o.User)
                .Where(od => od.Orders.User.user_id == userId)
                .ToListAsync();

            return orderDetailsList;
        }
       

        public async Task<OrderDetails> getInvoiceData(string razorPayOrderId)
        {
            try
            {
                var data = await dBContext.orderDetails.FirstOrDefaultAsync(i => i.razorpay_order_id == razorPayOrderId);
                return data;
            }catch(Exception ex)
            {
                Console.WriteLine("An error in repo getInvoice " + ex.Message);
                throw;
            }
        }

    }
}
