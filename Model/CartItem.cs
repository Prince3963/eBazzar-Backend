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
        public DateTime addedAt { get; set; }
                
        [ForeignKey("wishlist_id")]
        public int? wishlist_id { get; set; }

        [ForeignKey("product_id")]
        public int? product_id { get; set; }

    }
}
