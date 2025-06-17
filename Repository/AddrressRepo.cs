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


        public async Task<Address> AddAsync(Address address)
        {
            dBContext.addresse.Add(address);
            await dBContext.SaveChangesAsync();
            return address;
        }

        public async Task<Address> deleteAddress(int addressId)
        {
            var existAddress = await dBContext.addresse.FirstOrDefaultAsync(a => a.address_id == addressId);
            if (existAddress == null)
            {
                return null;
            }

            dBContext.addresse.Remove(existAddress);
            await dBContext.SaveChangesAsync();
            return existAddress;
            
        }

        public async Task<List<Address>> GetAddressById(int userId)
        {
            return await dBContext.addresse
                .Where(a => a.user_id == userId)
                .ToListAsync();
        }
        public async Task<Address> getAddressByAddressId(int address_id)
        {
            var existAddress = await dBContext.addresse.FirstOrDefaultAsync(a => a.address_id == address_id);
            if(existAddress == null)
            {
                return null;
            }
            return existAddress;
        }
    }
}
