using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBazzar.Model
{
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column ("RoleId", TypeName = "int(15)")]
        public int role_id { get; set; }
        [Column ("Role", TypeName = "varrchar(50)")]
        public string? role { get; set; }

        [Column("createdAt")]
        public DateTime createdAt { get; set; } = DateTime.Now;


    }
}
