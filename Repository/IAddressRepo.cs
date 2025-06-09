using eBazzar.Model;

namespace eBazzar.Repository
{
    public interface IAddressRepo
    {
        Task<List<Address>> GetAddressById(int userId);
        Task<Address> AddAsync(Address address);
    }
}
