using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBazzar.Model
{
    public class Wishlist
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int wishlist_id { get; set; }

        public DateTime createdAt { get; set; } = DateTime.Now;

        //User Navigation
        [ForeignKey("user_id")]
        public int? user_id { get; set; }


        //Navigation
        public ICollection<Discount>? discounts { get; set; }
    }
}
