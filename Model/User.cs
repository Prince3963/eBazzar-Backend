using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBazzar.Model
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int user_id { get; set; }
        [Column("UserName", TypeName = "varchar(50)")]
        public string? username { get; set; }

        [EmailAddress]
        [Column("UserEmail", TypeName = "varchar(255)")]

        public string? email { get; set; } 
        [Column("UserMobile", TypeName = "varchar(12)")]
        public string? mobile { get; set; }
        [Column("UserPassword", TypeName = "varchar(250)")]
        public string? password { get; set; }

        [Column("forgotPasswordToken", TypeName = "varchar(255)")]
        public string? forgotPasswordToken { get; set; } = null;

        [Column("tokanExpirationTime")]
        public DateTime? tokenExpirationTime { get; set; }
        public DateTime createdAt { get; set; } = DateTime.Now;

        //[Column("UserImage", TypeName = "varchar(255)")]
        //public string? user_image { get; set; }
        [Column("UserisActive", TypeName = "varchar(10)")]
        public string? user_isActive { get; set; }



        ////Navigation Property
        public ICollection<Wishlist>? wishlists { get; set; }
        public ICollection<Review>? reviews { get; set; }
        public ICollection<Order>? orders { get; set; }
        public ICollection<Payment>? payments { get; set; }
        //public ICollection<Address>? addresses { get; set; }
    }
}