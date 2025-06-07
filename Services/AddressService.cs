using eBazzar.DTO;
using eBazzar.HelperService;
using eBazzar.Model;
using eBazzar.Repository;

namespace eBazzar.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepo addressRepo;
        public AddressService(IAddressRepo addressRepo)
        {
            this.addressRepo = addressRepo;
        }

        public async Task<ServiceResponse<AddressDTO>> AddAsync(AddressDTO dto)
        {
            var address = new Address
            {
                number = dto.number,
                street = dto.street,
                city = dto.city,
                state = dto.state,
                zipCode = dto.zipCode,
                landmark = dto.landmark,
                country = dto.country,
                isDefault = dto.isDefault,
                username = dto.username,
                mobile = dto.mobile,
                user_id = dto.user_id
            };

            var saved = await addressRepo.AddAsync(address);
            dto.address_id = saved.address_id;

            return new ServiceResponse<AddressDTO>
            {
                data = dto,
                message = "Address saved successfully.",
                status = true
            };
        }

        public async Task<ServiceResponse<List<AddressDTO>>> GetByUserIdAsync(int userId)
        {
            var addresses = await addressRepo.GetByUserIdAsync(userId);
            var dtoList = addresses.Select(a => new AddressDTO
            {
                address_id = a.address_id,
                number = a.number,
                street = a.street,
                city = a.city,
                state = a.state,
                zipCode = a.zipCode,
                landmark = a.landmark,
                country = a.country,
                isDefault = a.isDefault,
                username = a.username,
                mobile = a.mobile,
                user_id = a.user_id
            }).ToList();

            return new ServiceResponse<List<AddressDTO>>
            {
                data = dtoList,
                message = "Addresses retrieved successfully for user.",
                status = true
            };
        }
    }
}
