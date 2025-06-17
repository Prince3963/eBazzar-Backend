namespace eBazzar.DTO
{
    public class InvoiceDTO
    {
        public string? razorPayOrderId { get; set; }
        public int? userId { get; set; }
        public string? username { get; set; }
        public string? email { get; set; }
        public decimal? amount { get; set; }
        public int? quntity { get; set; }
        public DateTime? date { get; set; }
        //public int? addressId { get; set; }
        public string? country {get; set;}
        public string? state {get; set;}
        public string? street {get; set;}
        public string? zipcode {get; set; }
        public string? landmark { get; set; }
        public string? num { get; set; }
        public string? productImage { get; set; }
        
    }
}
