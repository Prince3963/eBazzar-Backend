using eBazzar.DTO;
using eBazzar.HelperService;
using eBazzar.Model;
using eBazzar.Repository;
using eBazzar.Services;
using static CartItemDTO;

// Services/CartService.cs
// Services/CartService.cs
public class CartService : ICartService
{
    private readonly ICartItemRepository _cartRepo;
    public CartService(ICartItemRepository cartRepo)
    {
        _cartRepo = cartRepo;
    }

    public async Task AddToCartAsync(AddToCartRequest request)
    {
        if (request.Quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero.");

        var existingCartItem = await _cartRepo.GetCartItemAsync(request.UserId, request.ProductId);

        if (existingCartItem != null)
        {
            existingCartItem.quantity += request.Quantity;
            existingCartItem.addedAt = DateTime.Now;
            await _cartRepo.UpdateCartItemAsync(existingCartItem);
        }
        else
        {
            var newCartItem = new CartItem
            {
                user_id = request.UserId,
                product_id = request.ProductId,
                quantity = request.Quantity,
                addedAt = DateTime.Now
            };
            await _cartRepo.AddCartItemAsync(newCartItem);
        }

        await _cartRepo.SaveChangesAsync();
    }
}

