using eBazzar.DTO;
using eBazzar.HelperService;
using eBazzar.Services;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<AddressDTO>>>> GetByUser()
        {
            var userId = int.Parse(User.FindFirst("user_id")?.Value ?? "0");
            var response = await addressService.GetByUserIdAsync(userId);

            if (response.data == null)
            {
                return NotFound("No addresses found for this user.");
            }
            return Ok(response);
        }

        [Authorize]
        [HttpPost]
        [Route("user_id")]
        public async Task<ActionResult<ServiceResponse<AddressDTO>>> Post([FromBody] AddressDTO dto)
        {
            var user_id = int.Parse(User.FindFirst("user_id").Value ?? "0");
            //Console.WriteLine("user_id in controller:- " + user_id);
            var response = await addressService.AddAsync(dto, user_id);
            if (!response.status == false)
            {
                return Unauthorized(response.message);
            }
            return Ok(response);
        }
    }
}
