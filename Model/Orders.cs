using eBazzar.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Orders
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int order_id { get; set; }

    [Column("TotalPrice", TypeName = "decimal(18,2)")]
    public decimal? total_price { get; set; }

    [Column("OrderStatus", TypeName = "varchar(15)")]
    public string? status { get; set; } = "Pending";

    [Column("createdAt")]
    public DateTime createdAt { get; set; } = DateTime.Now;

    [Column("Extra", TypeName = "varchar(255)")]
    public string? extra { get; set; }

    // Foreign Keys
    [ForeignKey("razorpay_order_id")]
    public string? razorpay_order_id { get; set; }

    public int? user_id { get; set; }
    [ForeignKey("user_id")]
    public User? User { get; set; }

    [ForeignKey("address_id")]
    public int? address_id { get; set; }
    public int? payment_id { get; set; }
    [ForeignKey("payment_id")]

    //public Product? Product { get; set; }

    //Navigation properties
    public ICollection<OrderDetails>? orderDetails { get; set; }

}
