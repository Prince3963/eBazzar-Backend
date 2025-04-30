using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBazzar.Model
{
    public class Discount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("DiscountId", TypeName = "int(15)")]
        public int discount_id { get; set; }
        [Column("TotalValue", TypeName = "int(50)")]
        public int? total_value { get; set; }
        [Column("DiscountValidation", TypeName = "datetime(255)")]
        public DateTime? expiration_time { get; set; } 
        [Column("DiscountIamge", TypeName = "varchar(255)")]
        public string? Iamge { get; set; }
        [Column("DiscountType", TypeName = "varchar(15)")]
        public string? discount_type { get; set; } = "flat";

        [Column("createdAt")]
        public DateTime createdAt { get; set; } = DateTime.Now;
    }
}
