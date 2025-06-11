using eBazzar.Model;

namespace eBazzar.DTO
{
    public class CreateOrderRequest
    {
        public int UserId { get; set; }
        public decimal TotalAmount { get; set; }
        public string? Currency { get; set; }
        public List<OrderDetails> Items { get; set; } = new List<OrderDetails>();
    }
}
