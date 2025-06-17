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

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> getOrdersById()
        {
            var userId = int.Parse(User.FindFirst("user_id").Value ?? "0");
            if (userId == null)
            {
                return null;
            }

            var result = await orderDetails.getOrderDetailsById(userId);
            return Ok(result);
        }

        [Authorize]
        [HttpGet("getInvoiceData/{address_id}/{razorpay_order_id}")]
        public async Task<IActionResult> getInvoiceData(int address_id, string razorpay_order_id)
        {
            var userId = int.Parse(User.FindFirst("user_id").Value ?? "0");
            if (userId == null)
            {
                return null;
            }

            var result = await orderDetails.getInvoiceData(userId, address_id, razorpay_order_id);
            return Ok(result);
        }
    }
}
