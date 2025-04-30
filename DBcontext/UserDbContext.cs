using eBazzar.Model;
using Microsoft.EntityFrameworkCore;

namespace eBazzar.DBcontext
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> option) : base(option)
        {            
        }

        public DbSet<User> users { get; set; }
    }
}
