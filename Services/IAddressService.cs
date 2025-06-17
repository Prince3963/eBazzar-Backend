using System.Security.Claims;
using eBazzar.DTO;
using eBazzar.HelperService;
using eBazzar.Model;

namespace eBazzar.Services
{
    public interface IAddressService
    {
        Task<ServiceResponse<List<AddressDTO>>> GetByUserIdAsync(int userId);
        Task<ServiceResponse<string>> AddAsync(AddressDTO dto, int userId);
        Task<ServiceResponse<string>> deleteAsync(int addressid);
    }
}
