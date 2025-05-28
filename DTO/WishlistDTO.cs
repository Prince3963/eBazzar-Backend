namespace eBazzar.DTO
{
    public class WishlistDTO
    {
        public int WishlistId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public int? UserId { get; set; }
    }
}
