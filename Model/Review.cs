using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBazzar.Model
{
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int review_id { get; set; }
         public string? review_rate { get; set; }
        public string? review_text { get; set; }

        [Column("createdAt")]
        public DateTime createdAt { get; set; } = DateTime.Now;


// User Navigatioins
        public int user_id { get; set; }
        [ForeignKey("user_id")]

        public User? User { get; set; }

        // Product Navigation
        public int product_id { get; set; }
        [ForeignKey("product_id")]

        public Product? Product { get; set; }
    }
}
