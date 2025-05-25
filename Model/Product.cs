using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBazzar.Model
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int product_id { get; set; }
        [Column("ProductName", TypeName = "varchar(255)")]
        public string? product_name { get; set; }
        [Column("ProductDescription", TypeName = "varchar(255)")]
        public string? product_description { get; set; }
        [Column("ProductPrice", TypeName = "int")]
        public int? product_price { get; set; }
        [Column("ProductImage", TypeName = "varchar(255)")]
        public string? product_image { get; set; }
        [Column("ProductisActive", TypeName = "varchar(10)")]
        public string? product_isActive { get; set; }
        [Column("ProductSlug", TypeName = "varchar(255)")]
        public string? slug { get; set; } = null;

        [Column("createdAt")]
        public DateTime createdAt { get; set; } = DateTime.Now;

        public int? category_id { get; set; }

        [ForeignKey("category_id")]
        public Category? Category { get; set; }


        //Navigation Property
        public ICollection<Review>? reviews { get; set; }
        public ICollection<OrderDetails>? orderDetails { get; set; }
        public ICollection<User>? users { get; set; }

    }
}
