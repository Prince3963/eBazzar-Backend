using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBazzar.Model
{
    public class Orders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int order_id { get; set; }

        public string? razorpayOrderId { get; set; }
        [Column("TotalPrice", TypeName = "varchar(10)")]
        public decimal? total_price { get; set; }

        [Column("OrderStatus", TypeName = "varchar(15)")]
        public string? status { get; set; } = "Pending";

        [Column("createdAt")]
        public DateTime createdAt { get; set; } = DateTime.Now;

        [ForeignKey("user_id")]
        public int? user_id { get; set; }


        // Navigation properties
        public virtual ICollection<OrderDetails>? orderDetails { get; set; }
        
    }
}
