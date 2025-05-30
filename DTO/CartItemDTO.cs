public class CartItemDTO
{
    // DTOs/AddToCartRequest.cs
    public class AddToCartRequest
    {
        public int? UserId { get; set; }  // Nullable for guest
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }

}
