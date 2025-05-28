using eBazzar.DTO;

namespace eBazzar.Services
{
    public interface ICartService
    {
        Task<CartItemDTO> AddToCartAsync(int? wishlistId, int productId, int quantity);
        Task<WishlistDTO> GetOrCreateAnonymousWishlistAsync();
    }
}
