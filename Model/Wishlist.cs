using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBazzar.Model
{
    public class Wishlist
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("WishlistId", TypeName = "int(50)")]
        public int wishlist_id { get; set; }
        [Column("createdAt")]
        public DateTime createdAt { get; set; } = DateTime.Now;

        //User Navigation
        [ForeignKey("user_id")]
        public int? user_id { get; set; }

        public User? User { get; set; }

        // Product Navigation
        public int? product_id { get; set; }
        [ForeignKey("product_id")]
        public Product? Product { get; set; }

        //Discount Navigation
        public int? discount_id { get; set; }
        [ForeignKey("discount_id")]
        public Discount? Discount { get; set; }
    }
}
