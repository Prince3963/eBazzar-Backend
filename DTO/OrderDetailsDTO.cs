namespace eBazzar.DTO
{
    public class OrderDetailsDTO
    {
        public int order_id { get; set; }
        public int product_id { get; set; }
        public int user_id { get; set; }
        public string product_name { get; set; }
        public decimal final_price { get; set; }
        public int quantity { get; set; }
        public string product_image { get; set; }
        public string razorpay_order_id { get; set; }

    }
}
