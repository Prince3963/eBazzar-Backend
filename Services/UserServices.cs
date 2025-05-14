using eBazzar.DTO;
using eBazzar.Model;
using eBazzar.Repository;

namespace eBazzar.Services
{
    public class UserServices : IUsers
    {
        private readonly IUserRepo userRepo;

        public UserServices(IUserRepo userRepo)
        {
            this.userRepo = userRepo;
        }

        public async Task<UserDTO> addUser(UserDTO userDTO)
        {
            var user = new User
            {
                username = userDTO.username,
                email = userDTO.email,
                mobile = userDTO.mobile,
                password = userDTO.password//BCrypt.Net.BCrypt.HashPassword(userDTO.password),
            };
            Console.WriteLine("ser: " + user.password);

            await userRepo.addUser(user);

            return userDTO;
        }

        public async Task<LoginDTO> loginUser(LoginDTO loginDTO)
        {
            var login = new User
            {
                email = loginDTO.email,
                password = loginDTO.password
            };

            await userRepo.loginUser(login);
            return loginDTO;
        }

        public async Task<List<UserDTO>> viewUser()
        {
            var result = await userRepo.viewUser();
            return result.Select(u => new UserDTO
            {
                user_id = u.user_id,
                username = u.username,
                email = u.email,
                mobile = u.mobile,
                password = u.password,
            }).ToList();
        }
    }
}
