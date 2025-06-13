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
            try
            {
                var res = await dBContext.orders.Include(o => o.User).ToListAsync();
                return res;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
