using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBazzar.Model
{
    public class OrderDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("OrderId", TypeName = "int(15)")]
        public int orderDetaails_id { get; set; }
        [Column("OrderQuantity", TypeName = "int(255)")]
        public int? quantity { get; set; }
        [Column("OrderFinal Price", TypeName = "int(50)")]
        public int? final_price { get; set; }


        [Column("createdAt")]
        public DateTime createdAt { get; set; } = DateTime.Now;

        // Product Navigation
        public int product_id { get; set; }
        [ForeignKey("product_id")]

        public Product? Product { get; set; }

        //Order Navigation
        public int order_id { get; set; }
        [ForeignKey("order_id")]
        public Order? Order { get; set; }
    }
}
