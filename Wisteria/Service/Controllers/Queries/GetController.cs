using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using Wisteria.Domain.Entities;
using Wisteria.Service.Depend_Injections;

namespace Wisteria.Service.Controllers.Queries
{
    [ApiController]
    [Route("[controller]")]
    public class GetController : Controller
    {
        private readonly UserBase _db;
        private readonly IGet _get;
        public GetController(UserBase db,IGet get)
        {
            _db = db;
            _get = get;
        }
        [HttpGet]
        [Route("Users")]
        public IActionResult GetUsers()
        {
            var Users = _db.Users.Include(g => g.Communities).ToArray();

            return Ok(Users);
        }
        [HttpGet]
        [Route("UsersByindex")]
        public ActionResult<User> GetUsersbyIndex(int i)
        {
            var user = _get.GetUser(i);
            if (user is null)
            {
                return Ok("Not found");
            }
            return Ok(user.Include(g => g.Communities));
        }
        [HttpGet]
        [Route("Communitites")]
        public ActionResult<User> GetCommunities()
        {
            return Ok(_db.Communities.Include(g => g.Community_Members).ToArray());
        }
    }
}
