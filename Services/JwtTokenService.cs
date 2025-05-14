using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using eBazzar.DTO;
using eBazzar.Model;
using Microsoft.IdentityModel.Tokens;

namespace eBazzar.Services
{
    public class JwtTokenService
    {
        private readonly IConfiguration configuration;
        public JwtTokenService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        //Generate JWT function
        public string generateJWT(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtToken:SecurityKey"]));
            var tokenHandelar = new JwtSecurityTokenHandler();

            var claims = new[]
            {
                new Claim("user_id",user.user_id.ToString()),
                new Claim("email",user.email)
            };

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = configuration["JwtToken:Issuer"],
                Audience = configuration["JwtToken:Audience"],
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandelar.CreateToken(tokenDescription);
            return tokenHandelar.WriteToken(token);
        }

        
    }
}
