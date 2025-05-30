using eBazzar.DBcontext;
using eBazzar.Model;
using eBazzar.Repository;
using Microsoft.EntityFrameworkCore;

// Repository/CartItemRepository.cs
public class CartItemRepository : ICartItemRepository
{
    private readonly AppDBContext _context;
    public CartItemRepository(AppDBContext context)
    {
        this._context = context;
    }

    public async Task<CartItem?> GetCartItemAsync(int? userId, int productId)
    {
        return await _context.cartItems
            .FirstOrDefaultAsync(c => c.user_id == userId && c.product_id == productId);
    }

    public async Task AddCartItemAsync(CartItem cartItem)
    {
        await _context.cartItems.AddAsync(cartItem);
    }

    public async Task UpdateCartItemAsync(CartItem cartItem)
    {
        _context.cartItems.Update(cartItem);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    
}

