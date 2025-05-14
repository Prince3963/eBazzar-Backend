using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBazzar.Model
{
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? payment_id { get; set; }
        [Column("PaymentMethods", TypeName = "varchar(255)")]
        public string? payment_method { get; set; }
        [Column("PaymentTransaction", TypeName = "varchar(255)")]
        public string? payment_tarnsactionId { get; set; }
        [Column("PaymentDate")]
        public DateTime? payment_date { get; set; } = DateTime.Now;
        [Column("PaymentStatus", TypeName = "varchar(10)")]
        public string? payment_status { get; set; } = "pending";

        public DateTime createdAt { get; set; } = DateTime.Now;

        //User Navigation
        [ForeignKey("user_id")]
        public int? user_id { get; set; }

        //Order Navigation
        [ForeignKey("order_id")]
        public int? order_id { get; set; }

        //Discount Navigation
        [ForeignKey("discount_id")]
        public int? discount_id { get; set; }
    }
}
