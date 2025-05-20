using eBazzar.DBcontext;
using eBazzar.Model;
using eBazzar.Services;
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
            //Console.WriteLine("repo: "+user.password);
            try
            {
                await dbContext.AddAsync(user);
                await dbContext.SaveChangesAsync();
            }
            catch(Exception e)
            {
                Console.WriteLine("Failed to add User " + e);
                throw;
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
        
        public async Task<User> getUserByEmail(string email)
        {
            var existEmail = await dbContext.users.FirstOrDefaultAsync(u => u.email == email);
            return existEmail;
        }

        public async Task<List<User>> viewUser()
        {
            return await dbContext.users.ToListAsync();
        }

        public async Task updatePassword(User user)
        {
            dbContext.users.Update(user);
            await dbContext.SaveChangesAsync();
        }

        public Task<User> UserToken(string forgotPaswordToken)
        {
            return dbContext.users.FirstOrDefaultAsync(u => u.forgotPasswordToken == forgotPaswordToken);
        }
    }
}
