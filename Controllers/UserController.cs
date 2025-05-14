using eBazzar.DTO;
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
            //var JWT = jwtTokenService.generateJWT(result);
            //return Ok(new { result, JWT });
            return Ok(result);
        }
    }
}
