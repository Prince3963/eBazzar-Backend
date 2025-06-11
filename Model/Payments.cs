using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBazzar.Model
{
    public class Payments
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int payment_id { get; set; }

        [Column("Amount", TypeName = "decimal(18,2)")]
        public decimal amount { get; set; }

        [Column("PaymentDate")]
        public DateTime? payment_date { get; set; } = DateTime.Now;

        [Column("RazorpayOrderId", TypeName = "varchar(255)")]
        public string? razorpay_order_id { get; set; }

        public int? user_id { get; set; }

        [ForeignKey("user_id")]
        public User User { get; set; }

        [ForeignKey("order_id")]
        public int? order_id { get; set; }

        // Navigation
        //public Orders? Order { get; set; }
    }
}
