using eBazzar.DBcontext;
using eBazzar.Model;
using eBazzar.Repository;
using eBazzar.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eBazzar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUser iuser;
        private readonly JwtTokenService jwtTokenService;
        public UsersController(IUser user, JwtTokenService jwtTokenService)
        {
            this.iuser = user;
            this.jwtTokenService = jwtTokenService;
        }

        [HttpPost]
        public async Task<ActionResult> addUser([FromForm] User user)
        {
            await iuser.addUser(user);
            return Ok(user);
        }

        [HttpPost]
        [Route("/login")]
        public async Task<ActionResult> loginUser([FromForm] User user)
        {

            var existUser = await iuser.loginUser(user);
            if (existUser == null)
            {
                Console.WriteLine("usernot found from controller");
                return NotFound("User not found");
            }
            var JWT = jwtTokenService.generateJWT(existUser);
            return Ok(new {existUser , JWT});
        }

    }
}
