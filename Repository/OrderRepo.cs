using eBazzar.DBcontext;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace eBazzar.Repository
{
    public class OrderRepo : IOrderRepo
    {
        private readonly AppDBContext dBContext;
        public OrderRepo(AppDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task<Orders> addOrder(Orders orders)
        {
            await dBContext.orders.AddAsync(orders);
            await dBContext.SaveChangesAsync();
            return orders;
        }

        public async Task<List<Orders>> getAllOrders()
        {
            return await dBContext.orders
                .Include(o => o.Product)
                .Include(o => o.User)     
                .ToListAsync();
        }
    }
}
