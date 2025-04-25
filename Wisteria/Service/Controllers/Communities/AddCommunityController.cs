using Microsoft.AspNetCore.Mvc;
using Wisteria.Service.Depend_Injections.Add;

namespace Wisteria.Service.Controllers.Communities
{
    [ApiController]
    [Route("[controller]")]
    public class AddCommunityController : Controller
    {
        private readonly ICommunity _community;
        public AddCommunityController(ICommunity community)
        {
            _community = community;
        }
        [HttpPost]
        [Route("Create Community")]
        public IActionResult AddCommunity(string name)
        {
            return Ok(_community.CreateCommunity(name));
        }
        [HttpGet]
        [Route("Add User to community")]
        public IActionResult AddUserToCommunity(int User_Id,int Community_Id)
        {
            return Ok(_community.AddUserToCommunity(User_Id, Community_Id));
        }
    }
}
