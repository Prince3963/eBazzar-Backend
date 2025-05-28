using eBazzar.DTO;
using eBazzar.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eBazzar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddToCart([FromBody] CartItemDTO cartItemDto)
        {
            int? wishlistId = null;
            if (Request.Headers.ContainsKey("Wishlist-Id"))
            {
                int.TryParse(Request.Headers["Wishlist-Id"], out int parsedId);
                wishlistId = parsedId;
            }

            var addedItem = await _cartService.AddToCartAsync(wishlistId, cartItemDto.ProductId, cartItemDto.Quantity);

            var response = new
            {
                addedItem,
                wishlistId = wishlistId ?? addedItem.CartItemId
            };

            return Ok(response);
        }
    }

}
