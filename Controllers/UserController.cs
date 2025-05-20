using eBazzar.DTO;
using eBazzar.HelperService;
using eBazzar.Model;
using eBazzar.Services;
using Microsoft.AspNetCore.Mvc;

namespace eBazzar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsers iuser;
        private readonly JwtTokenService jwtTokenService;
        public UserController(IUsers iuser, JwtTokenService jwtTokenService)
        {
            this.iuser = iuser;
            this.jwtTokenService = jwtTokenService;
        }

        [HttpGet]
        public async Task<IActionResult> viewUser()
        {
            var result = await iuser.viewUser();
            return Ok(result);
        }

        [HttpPost]
        [Route("ForgotPassword")]
        public async Task<IActionResult> forgotPassword([FromForm] ForgotEmailDTO forgotEmail)
        {
            var response = new ServiceResponse<string>();
            try
            {
                var result = await iuser.userEmail(forgotEmail);
                return Ok(result);

            }catch(Exception e)
            {
                response.data = "0";
                response.message = e.Message;
                response.status = false;

                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpPost]
        [Route("resetPassword")]
        public async Task<IActionResult> resetPassword([FromForm] ForgotPasswordDTO forgotPasswordDTO)
        {
            var response = new ServiceResponse<string>();
            try
            {

                var result = await iuser.ForgotPasswrod(forgotPasswordDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                response.data = "0";
                response.message = ex.Message;
                response.status = false;

                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> addUser([FromForm] UserDTO userDTO)
        {
            var result = await iuser.addUser(userDTO);
            Console.WriteLine("ctr: " + userDTO.password);
            return Ok(result);
        }

        [HttpPost]
        [Route("/login")]
        public async Task<IActionResult> loginUser([FromForm] LoginDTO loginDTO)
        {
            var result = await iuser.loginUser(loginDTO);
            if (result == null)
            {
                Console.WriteLine("user not found from controller");
                return NotFound("User not found");
            }
            ;
            return Ok(result);
        }
    }
}
