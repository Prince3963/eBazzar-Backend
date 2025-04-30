using eBazzar.DBcontext;
using eBazzar.Model;
using Microsoft.EntityFrameworkCore;

namespace eBazzar.Repository
{
    public class UserRepo : IUser
    {
        private readonly UserDbContext userDbContext;
        public UserRepo(UserDbContext _userDbContext)
        {
            this.userDbContext = _userDbContext;            
        }

        public async Task<User> addUser(User user)
        {
            var newUser = new User
            {
                username = user.username,
                email = user.email,
                mobile = user.mobile,
                password = BCrypt.Net.BCrypt.HashPassword(user.password)
            };
            await userDbContext.AddAsync(newUser);
            await userDbContext.SaveChangesAsync();
            return newUser;
        }

        public async Task<User> loginUser(User user)
        {
            var existUser = await userDbContext.users.FirstOrDefaultAsync(u => u.email == user.email );
            if (existUser == null)
            {
                Console.WriteLine("User not found");
            //Console.WriteLine(existUser.email, existUser.password);
            }
            if (!BCrypt.Net.BCrypt.Verify(user.password, existUser.password))
            {
                Console.WriteLine("Invalid password");
            }
            return existUser;
        }

         //|| !BCrypt.Net.BCrypt.Verify(user.password, existUser.password)
    }
}
