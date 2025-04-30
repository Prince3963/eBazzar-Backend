using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBazzar.Model
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Column ("ProductId", TypeName = "int(50)")]
        public int product_id { get; set; }
        [Column("ProductName", TypeName = "varchar(255)")]
        public string? product_name { get; set; }
        [Column("ProductDescription", TypeName = "varchar(255)")]
        public string? product_description { get; set; }
        [Column("ProductPrice", TypeName = "int(50)")]
        public string? product_price { get; set; }
        [Column("ProductImage", TypeName = "varchar(255)")]
        public string? product_image { get; set; }
        [Column("ProductisActive", TypeName = "varchar(10)")]
        public int? product_isActive { get; set; }
        [Column("ProductSlug", TypeName = "varchar(255)")]
        public string? slug { get; set; } = null;

        [Column("createdAt")]
        public DateTime createdAt { get; set; } = DateTime.Now;

        //User Navigation
        [ForeignKey("user_id")]
        public int? user_id { get; set; } 
        public User? User { get; set; }

        //Category Navigation
        [ForeignKey("category_id")]
        public int? category_id { get; set; }
        public Category? Category { get; set; }

    }
}
