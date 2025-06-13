namespace eBazzar.DTO
{
    public class PaymentVerificationRequest
    {
        public string? RazorpayOrderId { get; set; }
        public string? RazorpayPaymentId { get; set; }
        public string? RazorpaySignature { get; set; }

        public List<CartItemDTO> CartItems { get; set; }
        public int AddressId { get; set; }
    }

}
