using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBazzar.Model
{
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("PaymentId", TypeName = "int(10)")]
        public int? payment_id { get; set; }
        [Column("PaymentMethods", TypeName = "varchar(255)")]
        public string? payment_method { get; set; }
        [Column("PaymentTransaction", TypeName = "varchar(255)")]
        public string? payment_tarnsactionId { get; set; }
        [Column("PaymentDate", TypeName = "datetime(255)")]
        public DateTime? payment_date { get; set; }
        [Column("PaymentStatus", TypeName = "varchar(10)")]
        public string? payment_status { get; set; } = "pending";

        [Column("createdAt")]
        public DateTime createdAt { get; set; } = DateTime.Now;

        //User Navigation
        public int? user_id { get; set; }
        [ForeignKey("user_id")]

        public User? User { get; set; }

        //Order Navigation
        public int order_id { get; set; }
        [ForeignKey("order_id")]
        public Order? Order { get; set; }
    }
}
