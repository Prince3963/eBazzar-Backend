using eBazzar.Model;

namespace eBazzar.Repository
{
    public interface IAddressRepo
    {
        Task<List<Address>> GetByUserIdAsync(int userId);
        Task<Address> AddAsync(Address address);
    }
}
