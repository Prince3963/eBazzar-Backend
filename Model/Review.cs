using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBazzar.Model
{
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int review_id { get; set; }
        [Column("ReviewRate", TypeName = "varchar(255)")]

        public string? review_rate { get; set; }
        [Column("ReviewText", TypeName = "varchar(255)")]

        public string? review_text { get; set; }

        public DateTime createdAt { get; set; } = DateTime.Now;


        // User Navigatioins
        [ForeignKey("user_id")]
        public int? user_id { get; set; }

        //Product Navigation
        [ForeignKey("product_id")]
        public int? product_id { get; set; }
    }
}
