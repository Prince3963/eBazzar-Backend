using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBazzar.Model
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column ("OrderId", TypeName = "int(50)")]
        public int order_id { get; set; }
        [Column("TotalPrice", TypeName = "varchar(10)")]
        public decimal? total_price { get; set; }

        [Column("OrderStatus", TypeName = "varchar(15)")]
        public string? status { get; set; } = "Pending";

        [Column("createdAt")]
        public DateTime createdAt { get; set; } = DateTime.Now;

        //User Navigation
        [ForeignKey("user_id")]
        public int? user_id { get; set; }
        public User? User { get; set; }

    }
}
