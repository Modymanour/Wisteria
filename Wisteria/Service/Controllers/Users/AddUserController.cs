using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Wisteria.Domain.Dtos;
using Wisteria.Service.Depend_Injections.Add;

namespace Wisteria.Service.Controllers.Users
{
    [ApiController]
    [Route("[controller]")]
    public class AddUserController : Controller//This controller should not be used and it is for debugging purposes
    {
        private readonly IUser _Adduser;
        public AddUserController(IUser Adduser)
        {
            _Adduser = Adduser;
        }
        [HttpPost]
        [Route("Create User")]
        public IActionResult Addusername(string name,string email,string password)
        {
            var user = new UserDto
            {
                Name = name,
                Email = email,
                Password = password
            };
            return Ok(_Adduser.register(user));
        }
    }
}
