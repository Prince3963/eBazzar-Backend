using eBazzar.DTO;
using eBazzar.HelperService;
using eBazzar.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eBazzar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService addressService;
        public AddressController(IAddressService addressService)
        {
            this.addressService = addressService;
        }

        [HttpGet("user_id")]
        public async Task<ActionResult<ServiceResponse<List<AddressDTO>>>> GetByUser(int user_id)
        {
            var userId = int.Parse(User.FindFirst("user_id").Value ?? "0");
            var response = await addressService.GetByUserIdAsync(userId);
            if (response == null)
            {
                return NotFound("User not found");
            }
            return Ok(response);
        }

        // POST api/address
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<AddressDTO>>> Post([FromBody] AddressDTO dto)
        {
            var response = await addressService.AddAsync(dto);
            return Ok(response);
        }
    }
}
