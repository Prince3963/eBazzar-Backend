using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBazzar.Model
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Column("Category_Id", TypeName = "int(15)")]
        public int category_id { get; set; }
        [Column("CategoryName", TypeName = "varchar(50)")]
        public string? category_name { get; set; }
        [Column("CategoryDescription", TypeName = "varchar(750)")]
        public string? category_description { get; set; }

        [Column("createdAt")]
        public DateTime createdAt { get; set; } = DateTime.Now;
    }
}
