using System.Security.Claims;
using eBazzar.DTO;
using eBazzar.HelperService;
using eBazzar.Model;
using eBazzar.Repository;

namespace eBazzar.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepo addressRepo;
        private readonly JwtTokenService jwtTokenService;
        private readonly IUserRepo userRepo;
        public AddressService(IAddressRepo addressRepo, JwtTokenService jwtTokenService, IUserRepo userRepo)
        {
            this.addressRepo = addressRepo;
            this.jwtTokenService = jwtTokenService;
            this.userRepo = userRepo;
        }

        public async Task<ServiceResponse<string>> AddAsync(AddressDTO dto, int user_id)
        {
            var response = new ServiceResponse<string>();

            var existUser = await userRepo.getUserById(user_id);

            if (existUser == null)
            {
                response.data = "0";
                response.message = "User not exist!";
                response.status = false;
                return response;
            }
            //Console.WriteLine("user_id in controller:- " + existUser);

            var address = new Address
            {
                number = dto.number,
                street = dto.street,
                city = dto.city,
                state = dto.state,
                zipCode = dto.zipCode,
                landmark = dto.landmark,
                country = dto.country,
                user_id = existUser.user_id,
                isDefault = dto.isDefault
            };

            await addressRepo.AddAsync(address);

            response.data = "1";
            response.message = "Address added.";
            response.status = true;

            return response;
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
                //username = a.username,
                //mobile = a.mobile,
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
