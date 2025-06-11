using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBazzar.Model
{
    public class Discount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int discount_id { get; set; }
        [Column("TotalValue", TypeName = "int")]
        public int? total_value { get; set; }
        [Column("DiscountValidation", TypeName = "varchar(30)")]
        public string? expiration_time { get; set; }
        [Column("DiscountIamge", TypeName = "varchar(255)")]
        public string? Iamge { get; set; }
        [Column("DiscountType", TypeName = "varchar(15)")]
        public string? discount_type { get; set; } = "flat";

        public DateTime createdAt { get; set; } = DateTime.Now;

        //Wishlist Navigation
        [ForeignKey("wishlist_id")]
        public int? wishlist_id { get; set; }

        //Navigation Property
        //public ICollection<Payments>? payments { get; set; }

    }
}
