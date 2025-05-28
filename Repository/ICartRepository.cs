using eBazzar.Model;

namespace eBazzar.Repository
{
    public interface ICartRepository
    {
        Task<CartItem> AddToCartAsync(int wishlistId, int productId, int quantity);
        Task<Wishlist> GetOrCreateAnonymousWishlistAsync();
        Task<Wishlist> GetWishlistByIdAsync(int wishlistId);
        // Optional
        Task<IEnumerable<CartItem>> GetCartItemsByWishlistIdAsync(int wishlistId);
    }
}
