using eBazzar.DBcontext;
using eBazzar.Model;

namespace eBazzar.Repository
{
    public class PayemntRepo : IPaymentRepo
    {
        private readonly AppDBContext dBContext;
        public PayemntRepo(AppDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task<Payments> addPayment(Payments payments)
        {
            try
            {
                await dBContext.payments.AddAsync(payments);
                await dBContext.SaveChangesAsync();
                return payments;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message ?? ex.Message);
                throw;
            }
        }
    }
}
