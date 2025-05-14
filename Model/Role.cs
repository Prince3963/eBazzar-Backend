using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBazzar.Model
{
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int role_id { get; set; }

        [Column("Role", TypeName = "varchar(50)")]
        public string? role { get; set; }

        public DateTime? createdAt { get; set; } = DateTime.Now;

        //Navigation property
        public ICollection<User>? users { get; set; }
    }
}
