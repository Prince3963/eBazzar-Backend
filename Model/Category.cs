using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBazzar.Model
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int category_id { get; set; }
        [Column("CategoryName", TypeName = "varchar(50)")]
        public string? category_name { get; set; }
        [Column("CategoryDescription", TypeName = "varchar(500)")]
        public string? category_description { get; set; }

        public DateTime createdAt { get; set; } = DateTime.Now;

        //Navigation property 
        public ICollection<Product>? products { get; set; }
    }
}
