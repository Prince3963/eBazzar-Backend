using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Identity.Client;

namespace eBazzar.Model
{
    public class Wishlist
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int wishlist_id { get; set; }

        public DateTime createdAt { get; set; } 
        public DateTime ExpiresAt { get; set; } 

        public Wishlist()
        {
            createdAt = DateTime.Now;
            ExpiresAt = createdAt.AddDays(7);
        }

        //User Navigation
        [ForeignKey("user_id")]
        public int? user_id { get; set; } = null;


        //Navigation
        public ICollection<Discount>? discounts { get; set; }
    }
}
