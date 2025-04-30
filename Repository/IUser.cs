using eBazzar.Model;

namespace eBazzar.Repository
{
    public interface IUser
    {
        Task<User> addUser(User user);

        Task<User> loginUser(User user);
    }
}
