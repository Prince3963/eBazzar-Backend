using eBazzar.DTO;
using eBazzar.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eBazzar.Controllers
{
    [Route("api/payment")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            this.paymentService = paymentService;
        }

        [Authorize]
        [HttpPost("create-order")]
        public async Task<IActionResult> CreateOrder([FromBody] PaymentRequest request)
        {
            try
            {
                var userId = int.Parse(User.FindFirst("user_id").Value ?? "0");

                var order = await paymentService.CreateOrderAsync(request, userId);
                //return Ok(new
                //{
                //    id = order.razorpay_order_id,
                //    amount = order.amount * 100,
                //    currency = "INR"
                //});

                return Ok(order);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [Authorize]
        [HttpPost("verify-payment")]
        public IActionResult VerifyPayment([FromBody] PaymentVerificationRequest request)
        {
            try
            {
                var isValid = paymentService.VerifyPayment(request);
                return Ok(new { success = isValid });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
