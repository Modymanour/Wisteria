using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Mvc;
using Wisteria.Service.Depend_Injections.Modify;
using Wisteria.Service.Depend_Injections.Register;

namespace Wisteria.Service.Controllers.Modify
{
    [ApiController]
    [Route("[controller]")]
    public class ModifyController : Controller
    {
        private readonly ModifyUser _modifyUser;
        public ModifyController(ModifyUser modifyUser)
        {
            _modifyUser = modifyUser;
        }
        [HttpGet]
        [Route("Change Name")]
        public IActionResult Modifyname(int id,string name)
        {
            return Ok(_modifyUser.Modifyname(id, name));
        }
        [HttpGet]
        [Route("Change Email")]
        public IActionResult Modifyemail(int id, string email)
        {
            return Ok(_modifyUser.ModifyEmail(id, email));
        }
        [HttpGet]
        [Route("Change Password")]
        public IActionResult ModifyPassword(int id,string old_password, string new_password)
        {
            return Ok(_modifyUser.ModifyPassword(id, old_password, new_password));
        }
    }
}
