namespace eBazzar.DTO
{
    public class PaymentRequest
    {
        public decimal amount { get; set; }
        public string? razorpayOrderId { get; set; }
        public int? user_id { get; set; }
        public int? order_id { get; set; }
    }

}
