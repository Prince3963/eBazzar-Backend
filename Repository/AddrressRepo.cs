using eBazzar.DBcontext;
using eBazzar.Model;
using Microsoft.EntityFrameworkCore;

namespace eBazzar.Repository
{
    public class AddrressRepo : IAddressRepo
    {
        private readonly AppDBContext dBContext;
        public AddrressRepo(AppDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task<List<Address>> GetByUserIdAsync(int userId)
        {
            return await dBContext.addresse
                .Where(a => a.user_id == userId)
                .ToListAsync();
        }

        public async Task<Address> AddAsync(Address address)
        {
            dBContext.addresse.Add(address);
            await dBContext.SaveChangesAsync();
            return address;
        }
    }
}
