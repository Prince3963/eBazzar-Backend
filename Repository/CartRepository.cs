using eBazzar.DBcontext;
using eBazzar.Model;
using eBazzar.Repository;
using Microsoft.EntityFrameworkCore;

public class CartRepository : ICartRepository
{
    private readonly AppDBContext _context;

    public CartRepository(AppDBContext context)
    {
        _context = context;
    }

    public async Task<Wishlist> GetOrCreateAnonymousWishlistAsync()
    {
        // Check if there's already a valid wishlist for this anonymous user (maybe stored in cookie/session)
        var wishlist = await _context.wishlists
                            .Where(w => w.user_id  == null && w.ExpiresAt > DateTime.Now)
                            .OrderByDescending(w => w.createdAt)
                            .FirstOrDefaultAsync();

        if (wishlist == null)
        {
            wishlist = new Wishlist();
            _context.wishlists.Add(wishlist);
            await _context.SaveChangesAsync();
        }
        return wishlist;
    }

    public async Task<CartItem> AddToCartAsync(int wishlistId, int productId, int quantity)
    {
        // Check if product already exists in cart for this wishlist
        var cartItem = await _context.cartItems
                            .FirstOrDefaultAsync(c => c.wishlist_id == wishlistId && c.product_id == productId);

        if (cartItem != null)
        {
            cartItem.quantity += quantity;
            cartItem.addedAt = DateTime.Now;
            _context.cartItems.Update(cartItem);
        }
        else
        {
            cartItem = new CartItem
            {
                wishlist_id = wishlistId,
                product_id = productId,
                quantity = quantity,
                addedAt = DateTime.Now
            };
            await _context.cartItems.AddAsync(cartItem);
        }

        await _context.SaveChangesAsync();
        return cartItem;
    }

    public async Task<Wishlist> GetWishlistByIdAsync(int wishlistId)
    {
        return await _context.wishlists.FindAsync(wishlistId);
    }

    public async Task<IEnumerable<CartItem>> GetCartItemsByWishlistIdAsync(int wishlistId)
    {
        return await _context.cartItems.Where(c => c.wishlist_id == wishlistId).ToListAsync();
    }
}
