using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using vcapp.Auth.API.Models;

namespace vcapp.Auth.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLogin login)
        {
            if (login.Username != "string" || login.Password != "string")
                return Unauthorized();

            var claims = new[]
            {
        new Claim(ClaimTypes.Name, login.Username)
    };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("super-secret-key-1234-super-secret-key-1234"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "videoclub",
                audience: "videoclub",
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new { token = tokenString }); 
        }

        
        private IActionResult LoginOld([FromBody] UserLogin login)
        {
            if (login.Username != "string" || login.Password != "string")
            {
                return Unauthorized();
            }

            //var claims = new[]
            //{
            // new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Name, login.Username)
            //};

            //var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("your-256-bit-secret"));
            /*
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("mock-jwt-token"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new System.IdentityModel.Tokens.Jwt.JwtSecurityToken(
                issuer: "localhost:7112",
                audience: "localhost:7112",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);
            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token)  });
            */


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("super-secret-key-1234-super-secret-key-1234"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: "videoclub",
                audience: "videoclub",
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new { Token = tokenString });

            // In a real application, you would generate a JWT or similar token here
            //var tokenMock = "mock-jwt-token";
            //return Ok(new { Token = tokenMock });   
        }
    }
}
