using eBazzar.DTO;
using eBazzar.HelperService;
using eBazzar.Model;

namespace eBazzar.Services
{
    public interface IAddressService
    {
        Task<ServiceResponse<List<AddressDTO>>> GetByUserIdAsync(int userId);
        Task<ServiceResponse<AddressDTO>> AddAsync(AddressDTO dto);
    }
}
