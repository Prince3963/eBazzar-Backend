using eBazzar.Model;

namespace eBazzar.Repository
{
    public interface IUserRepo
    {
        Task addUser(User user);
        Task loginUser(User user);
        Task<List<User>> viewUser();

        Task<User> getUserById(int id);


    }
}
