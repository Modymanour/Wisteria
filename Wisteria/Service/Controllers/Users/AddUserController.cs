using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Wisteria.Service.Depend_Injections.Add;

namespace Wisteria.Service.Controllers.Users
{
    [ApiController]
    [Route("[controller]")]
    public class AddUserController : Controller
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
            return Ok(_Adduser.register(name, email, password));
        }
    }
}
