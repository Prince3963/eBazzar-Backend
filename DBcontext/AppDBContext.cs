using eBazzar.Model;
using Microsoft.EntityFrameworkCore;

namespace eBazzar.DBcontext
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions <AppDBContext> options) : base(options)
        {
            
        }

        public DbSet<User> users { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<Wishlist> wishlists { get; set; }
        public DbSet<Review> reviews { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Payment> payments { get; set; }
        public DbSet<OrderDetails> orderDetails { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Discount> discounts { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<CartItem> cartItems { get; set; }

    }
}
