using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBazzar.Model
{
    public class CartItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int cartItmeId { get; set; }
        public int quantity { get; set; }
        public int? user_id { get; set; } = null;

        [ForeignKey(nameof(Product))]
        public int? product_id { get; set; }
        public Product? Product { get; set; }

        public DateTime addedAt { get; set; } = DateTime.Now;


    }
}
