using eBazzar.DTO;
using eBazzar.Model;

namespace eBazzar.Repository
{
    public interface IUserRepo
    {
        Task addUser(User user);
        Task<List<User>> viewUser();
        Task<User> getUserById(int id);
        Task<User?> getUserByEmail(string email);
        Task updatePassword(User user);
        Task updateUser(User user);
        Task<User> UserToken(string forgotPasswordToken);
        Task<User> updateUserStatus(UserStatusDTO userStatusDTO, int user_id);
    }
}
