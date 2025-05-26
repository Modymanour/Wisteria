using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Wisteria.Domain.Dtos;
using Wisteria.Domain.Entities;
using Wisteria.Service.Depend_Injections.Add;
using Wisteria.Service.Depend_Injections.LogIn;

namespace Wisteria.Service.Controllers.Authentication
{
    [ApiController]
    [Route("[controller]")]
    public class Authentication : Controller
    {
        private readonly IUser _Adduser;
        private readonly ILogIn _Login;
        private readonly IConfiguration _config;
        public Authentication(IUser Adduser,ILogIn Login,IConfiguration config)
        {
            _Adduser = Adduser;
            _Login = Login;
            _config = config;
        }
        [HttpPost]
        [Route("Register")]// same as endpoint adduser
        public ActionResult<User> Register(UserDto u)
        {
            var user = _Adduser.register(u);
            if (user == null)
            {
                return BadRequest("Json is empty");
            }
            else if(user.Name == "Password is invalid")
            {
                return BadRequest(user.Name);
            }
            else if(user.Name == "Email is invalid")
            {
                return BadRequest(user.Name);
            }
            else if(user.Name == "Both the Email & Password are invalid")
            {
                return BadRequest(user.Name);
            }
            else if(user.Name == "Name is already taken")
            {
                return BadRequest(user.Name);
            }
            string Token = CreateToken(user);
            return Ok(Token);
        }
        [HttpPost]
        [Route("Login")]
        public ActionResult<User> LogIn(UserDtoLogin u)
        {
            var user = _Login.Login(u);
            if (user == null)
            {
                return BadRequest("empty given json");
            }
            else if (user.Name == "notfound")
            {
                return BadRequest("Wrong Email");
            }
            else if (user.Name == "WrongPassword")
            {
                return BadRequest("Wrong Password");
            }
            string Token = CreateToken(user);
            return Ok(Token);
        }
        [Authorize]
        [HttpGet]
        public ActionResult Authenticated()
        {
            return Ok("You are authenticated");
        }
        private string CreateToken(User u)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,u.Name),
                new Claim(ClaimTypes.Email,u.Email),
                new Claim(ClaimTypes.NameIdentifier,u.User_ID.ToString())
            };
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config.GetValue<string>("JwtSettings:Token")!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var TokenDescriptor = new JwtSecurityToken(
                issuer: _config.GetValue<string>("JwtSettings:Issuer"),
                audience: _config.GetValue<string>("JwtSettings:Audience"),
                claims: claims,
                expires: DateTime.UtcNow.AddDays(2),//EXPIRATION DATE
                signingCredentials: creds
                );
            return new JwtSecurityTokenHandler().WriteToken(TokenDescriptor);
        }
    }
}
