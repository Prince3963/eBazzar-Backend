using eBazzar.DTO;
using eBazzar.Model;

namespace eBazzar.Services
{
    public interface IUsers
    {
        Task<UserDTO> addUser(UserDTO userDTO);
        Task<LoginDTO> loginUser(LoginDTO loginDTO);
        Task<List<UserDTO>> viewUser();
    }
}
