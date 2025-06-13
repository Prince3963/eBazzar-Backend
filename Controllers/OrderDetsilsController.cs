using eBazzar.DTO;
using System.Security.Claims;
using eBazzar.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace eBazzar.Controllers
{
    [Route("api/test/")]
    [ApiController]
    public class OrderDetsilsController : ControllerBase
    {
        private readonly IOrderDetailsService orderDetails;
        public OrderDetsilsController(IOrderDetailsService orderDetails)
        {
            this.orderDetails = orderDetails;
        }

        [HttpPost("addOrderDetails")]
        public async Task<IActionResult> AddOrderDetails([FromBody] OrderDetailsDTO orderDetailsDTO)
        {
            var result = await orderDetails.addOrderDetails(orderDetailsDTO);
            return Ok(result);
        }
    }
}
