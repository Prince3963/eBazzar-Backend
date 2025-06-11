namespace eBazzar.DTO
{
    public class PaymentResult
    {
        public bool Success { get; set; }
        public int OrderId { get; set; }
        public int? PaymentId { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
    }
}
