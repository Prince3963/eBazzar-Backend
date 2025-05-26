using eBazzar.DTO;
using eBazzar.HelperService;
using eBazzar.Model;

namespace eBazzar.Services
{
    public interface IUsers
    {
        Task<ServiceResponse<string>> addUser(UserDTO userDTO);
        Task<List<UserDTO>> viewUser();
        Task<ServiceResponse<string>> loginUser(LoginDTO loginDTO);
        Task<ServiceResponse<string>> userEmail(ForgotEmailDTO forgotEmail); 
        Task<ServiceResponse<string>> ForgotPasswrod(ForgotPasswordDTO forgotPassword);
        Task<ServiceResponse<string>> updateUserProfile(int id, ProfileUpdateDTO profileUpdateDTO);
        Task<ProfileUpdateDTO> getDataById(int id);
    }
}
