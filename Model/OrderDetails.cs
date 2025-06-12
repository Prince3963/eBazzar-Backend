using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBazzar.Model
{
    public class OrderDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int orderDetails_id { get; set; }

        [Column("OrderQuantity", TypeName = "int")]
        public int? quantity { get; set; }

        [Column("OrderFinalPrice", TypeName = "int")]
        public int? final_price { get; set; }

        public DateTime createdAt { get; set; } = DateTime.Now;


        public int? product_id { get; set; }
        [ForeignKey("product_id")]
        public Product? Product { get; set; }

        public int? order_id { get; set; }
        [ForeignKey("order_id")]
        public Orders? Order { get; set; }

        // Optional navigation
    }
}
