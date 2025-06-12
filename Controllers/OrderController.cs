using eBazzar.DTO;
using eBazzar.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eBazzar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;
        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }


        [Authorize]
        [HttpPost]
        [Route("addOrder")]
        public async Task<IActionResult> addOrder([FromForm] OrdersDTO ordersDTO)
        {
            var userId = int.Parse(User.FindFirst("user_id").Value ?? "0");

            var result = await orderService.addOrder(ordersDTO, userId);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> getAllOrders()
        {
            return Ok(await orderService.getAllOrders());
        }

    }
}
