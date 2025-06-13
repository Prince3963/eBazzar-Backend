namespace eBazzar.DTO
{
    public class OrdersDTO
    {
        public string? username { get; set; }
        public int? address_id { get; set; }
        public string? razorpay_order_id { get; set; }
        public decimal? total_price { get; set; }
        public string? status { get; set; }
        public DateTime createdAt { get; set; }

    }
}
