using eBazzar.DBcontext;
using eBazzar.Model;
using Microsoft.EntityFrameworkCore;

namespace eBazzar.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly AppDBContext dbContext;
        public UserRepo(AppDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task addUser(User user)
        {
            Console.WriteLine("repo: "+user.password);
            try
            {
                await dbContext.AddAsync(user);
                await dbContext.SaveChangesAsync();
            }
            catch(Exception e)
            {
                Console.WriteLine("Failed to add User " + e);
            }
        }

        public async Task<User> getUserById(int user_id)
        {
            var existUser = await dbContext.users.FirstOrDefaultAsync(u => u.user_id == user_id);
            if (existUser == null)
            {
                return null;
            }
            return existUser;
        }

        public async Task loginUser(User user)
        {
            var existUser = await dbContext.users.FirstOrDefaultAsync(u => u.email == user.email);
            if (existUser == null)
            {
                Console.WriteLine("User not found");
            }
            if (!BCrypt.Net.BCrypt.Verify(user.password, existUser.password))
            {
                Console.WriteLine("Invalid password");
            }
        }

        public async Task<List<User>> viewUser()
        {
            return await dbContext.users.ToListAsync();
        }
    }
}
