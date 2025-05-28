using eBazzar.DTO;
using eBazzar.Repository;
using eBazzar.Services;

public class CartService : ICartService
{
    private readonly ICartRepository _cartRepository;

    public CartService(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task<WishlistDTO> GetOrCreateAnonymousWishlistAsync()
    {
        var wishlist = await _cartRepository.GetOrCreateAnonymousWishlistAsync();
        return new WishlistDTO
        {
            WishlistId = wishlist.wishlist_id,
            CreatedAt = wishlist.createdAt,
            ExpiresAt = wishlist.ExpiresAt,
            UserId = wishlist.user_id
        };
    }

    public async Task<CartItemDTO> AddToCartAsync(int? wishlistId, int productId, int quantity)
    {
        if (wishlistId == null)
        {
            // Create or get anonymous wishlist
            var wishlist = await _cartRepository.GetOrCreateAnonymousWishlistAsync();
            wishlistId = wishlist.wishlist_id;
        }

        var cartItem = await _cartRepository.AddToCartAsync(wishlistId.Value, productId, quantity);

        return new CartItemDTO
        {
            CartItemId = cartItem.cartItmeId,
            ProductId = cartItem.product_id.Value,
            Quantity = cartItem.quantity
        };
    }
}