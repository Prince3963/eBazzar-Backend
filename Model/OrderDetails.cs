using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBazzar.Model
{
    public class OrderDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int orderDetailsId { get; set; }

        public int? order_id { get; set; }
        [ForeignKey("order_id")]
        public Orders Orders { get; set; }

        [Column("productId", TypeName = "int")]

        public int productId { get; set; }
        [Column("productName", TypeName = "varchar(500)")]
        public string productName { get; set; }
        [Column("productPrice", TypeName = "decimal(18,2)")]
        public decimal productPrice { get; set; }
        [Column("quantity", TypeName = "int")]
        public int quantity { get; set; }
        [Column("productImage", TypeName = "varchar(1000)")]
        public string? productImage { get; set; }

        public string razorpay_order_id { get; set; }
    }
}
