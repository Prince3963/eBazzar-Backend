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
    }
}
