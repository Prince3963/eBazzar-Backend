using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBazzar.Model
{
    public class OrderDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int orderDetaails_id { get; set; }
        [Column("OrderQuantity", TypeName = "int")]
        public int? quantity { get; set; }
        [Column("OrderFinalPrice", TypeName = "int")]
        public int? final_price { get; set; }

        public DateTime createdAt { get; set; } = DateTime.Now;

        // Product Navigation
        [ForeignKey("product_id")]
        public int? product_id { get; set; }

        //Order Navigation
        [ForeignKey("order_id")]
        public int? order_id { get; set; }
    }
}
