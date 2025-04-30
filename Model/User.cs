using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBazzar.Model
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column ("UserId", TypeName = "int(15)")]
        public int user_id { get; set; }
        [Column ("UserName", TypeName = "varchar(50)")]
        public string? username { get; set; }

        [EmailAddress]  //For email
        [Column ("UserEmail", TypeName = "varchar(255)")]
        public string? email { get; set; }
        [Column ("UserMobile", TypeName = "int(20)")]
        public string? mobile { get; set; }
        [Column ("UserPassword", TypeName = "varchar(50)")]
        public string? password { get; set; }

        [Column("createdAt")]
        public DateTime createdAt { get; set; } = DateTime.Now;

        //Role Navigation
        [ForeignKey("role_id")]
        public int? role_id { get; set; }
        public Role? Role { get; set; }
    }
}