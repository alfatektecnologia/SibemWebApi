using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SibemWebApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace SibemWebApi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            if(loginModel.Email == "emanoel_oliveira@outlook.com" && loginModel.Password == "17hxhAKCde")
            {
                var token = GerarTokenJWT();
                return Ok(new {token});
            }
            return BadRequest(new {mensagem = "Credenciais invalidas"});
        }

        private string GerarTokenJWT()
        {
            string secretKey = "252167c1-ed92-4dd4-a5ee-7b6cf1525d2b";
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credencial = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: "Alfatek Tecnologia Ltda",
                audience: "SibemWebApi",
                claims: null,
                expires: DateTime.Now.AddHours(3) ,
                signingCredentials: credencial

                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
