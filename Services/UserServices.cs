using BCrypt.Net;
using eBazzar.DTO;
using eBazzar.HelperService;
using eBazzar.Model;

using eBazzar.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace eBazzar.Services
{
    public class UserServices : IUsers
    {
        private readonly IUserRepo userRepo;
        private readonly JwtTokenService jwtTokenService;
        private readonly IEmailService emailService;

        public UserServices(IUserRepo userRepo, JwtTokenService jwtTokenService, IEmailService emailService)
        {
            this.userRepo = userRepo;
            this.jwtTokenService = jwtTokenService;
            this.emailService = emailService;
        }



        public async Task<ServiceResponse<string>> addUser(UserDTO userDTO)
        {
            var response = new ServiceResponse<string>();

            var existUser = await userRepo.getUserByEmail(userDTO.email);
            if (existUser != null)
            {
                response.data = "0";
                response.message = "Registered email already exists";
                response.status = false;
                return response;
            }

            var user = new User
            {
                username = userDTO.username,
                email = userDTO.email,
                mobile = userDTO.mobile,
                password = BCrypt.Net.BCrypt.HashPassword(userDTO.password),
            };

            await userRepo.addUser(user);

            response.data = "1";
            response.message = "Registration successful";
            response.status = true;
            return response;
        }

        //Get Company Profile



        public async Task<ServiceResponse<string>> loginUser(LoginDTO loginDTO)
        {
            var response = new ServiceResponse<string>();
            var existUser = await userRepo.getUserByEmail(loginDTO.email);

            if (existUser == null || string.IsNullOrWhiteSpace(existUser.password) ||
            !existUser.password.StartsWith("$2") ||
            !BCrypt.Net.BCrypt.Verify(loginDTO.password, existUser.password))
            {
                response.data = "0";
                response.message = "Invalid email or password.";
                response.status = false;
                return response;
            }


            response.data = jwtTokenService.generateJWT(existUser);
            response.message = "Login successfully";
            response.status = true;
            return response;
        }

        public async Task<ServiceResponse<string>> userEmail(ForgotEmailDTO forgotEmail)
        {
            var response = new ServiceResponse<string>();
            var existEmail = await userRepo.getUserByEmail(forgotEmail.email);

            if (existEmail == null)
            {
                response.data = "0";
                response.message = "Email not found.";
                response.status = false;
                return response;
            }

            string token = Guid.NewGuid().ToString();
            DateTime tokenExpirationTime = DateTime.Now.AddMinutes(10);

            string hashToken = BCrypt.Net.BCrypt.HashPassword(token);

            existEmail.forgotPasswordToken = hashToken;
            existEmail.tokenExpirationTime = tokenExpirationTime;

            await userRepo.updatePassword(existEmail);

            response.data = "1";
            response.message = "Forgot password link sent to your email.";
            response.status = true;

            string subject = "Forgot Your Password - eBazzar";
            string body = emailService.createResetPasswordEmailBody(forgotEmail.email, existEmail.forgotPasswordToken);

            await emailService.sendEmail(forgotEmail.email, subject, body);

            return response;
        }

        public async Task<ServiceResponse<string>> ForgotPasswrod(ForgotPasswordDTO forgotPassword)
        {
            var response = new ServiceResponse<string>();
            var existEmail = await userRepo.UserToken(forgotPassword.forgotPasswordToken);

            if (existEmail == null)
            {
                response.data = "0";
                response.message = "Invalid token.";
                response.status = false;
                return response;
            }

            if (DateTime.Now > existEmail.tokenExpirationTime)
            {
                response.data = "0";
                response.message = "Token has expired.";
                response.status = false;
                return response;
            }

            if (forgotPassword.forgotPasswordToken != existEmail.forgotPasswordToken)
            {
                response.data = "0";
                response.message = "Invalid token.";
                response.status = false;
                return response;
            }

            existEmail.password = BCrypt.Net.BCrypt.HashPassword(forgotPassword.forgotPassword);
            await userRepo.updatePassword(existEmail);

            response.data = "1";
            response.message = "Password reset successfully.";
            response.status = true;

            return response;

        }

        public async Task<ServiceResponse<string>> updateUserProfile(int id, ProfileUpdateDTO profileUpdateDTO)
        {
            var resultResponse = new ServiceResponse<string>();

            //user ni id lidhi ane check kari a exist 6e k ni 
            var updateProfile = await userRepo.getUserById(id);

            //Jo exist ni hoy to 
            if (updateProfile == null)
            {
                resultResponse.data = "0";
                resultResponse.message = "User not found";
                resultResponse.status = false;

                return resultResponse;
            }

            //Exist hoi to 
            //Mtlb agar profileUpdateDTO.username null nahi he to yahi value updateProfile.username ko assign ki jayegi bydefault
            updateProfile.username = profileUpdateDTO.username ?? updateProfile.username;
            updateProfile.email = profileUpdateDTO.email ?? updateProfile.email;
            updateProfile.mobile = profileUpdateDTO.mobile ?? updateProfile.mobile;

            if (!string.IsNullOrWhiteSpace(profileUpdateDTO.password))
            {
                updateProfile.password = BCrypt.Net.BCrypt.HashPassword(profileUpdateDTO.password);
            }

            //Call repo method
            await userRepo.updateUser(updateProfile);

            resultResponse.data = "1";
            resultResponse.message = "Profile Update Successfully";
            resultResponse.status = true;

            return resultResponse;
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

        public async Task<ProfileUpdateDTO> getDataById(int id)
        {
            var existUser = await userRepo.getUserById(id);
            if (existUser == null)
            {
                return null;
            }

            return new ProfileUpdateDTO
            {
                username = existUser.username,
                email = existUser.email,
                mobile = existUser.mobile,

            };

        }
    }
}
