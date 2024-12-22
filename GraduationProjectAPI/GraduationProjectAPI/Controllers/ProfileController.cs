using Microsoft.AspNetCore.Mvc;
using GraduationProjectAPI.Infrastructure;
using GraduationProjectAPI.Model;
namespace GraduationProjectAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProfileController : Controller
    {
        private readonly IProfile db;
        public ProfileController(IProfile _db)
        {
            db = _db;
        }
        [HttpGet]
        [ActionName("GetFollow")]
        public IActionResult GetFollow([FromQuery] int IdUser)
        {
            if(IdUser != 0)
            {
                var data = db.UserFollow(IdUser);
                if(data != null)
                {
                    return Ok(data);
                }
                else
                {
                    //  return NotFound();
                    return Ok(new List<object>());
                }
            }
            else
            {
                // return BadRequest();
                return Ok(new List<object>());
            }
        }
        [HttpGet]
        [ActionName("GetFollowed")]
        public IActionResult GetFollowed([FromQuery] int IdUser)
        {
            if (IdUser != 0)
            {
                var data = db.FollowUser(IdUser);
                if (data != null)
                {
                    return Ok(data);
                }
                else
                {
                    // return NotFound();
                    return Ok(new List<object>());
                }
            }
            else
            {
                // return BadRequest();
                return Ok(new List<object>());
            }
        }
        [HttpGet]
        [ActionName("GetGroups")]
        public IActionResult GetGroups([FromQuery] int IdUser)
        {
            if (IdUser != 0)
            {
                var data = db.UserGroups(IdUser);
                if (data != null)
                {
                    return Ok(data);
                }
                else
                {
                    // return NotFound();
                    return Ok(new List<object>());
                }
            }
            else
            {
                // return BadRequest();
                return Ok(new List<object>());
            }
        }
        [HttpGet]
        [ActionName("GetPosts")]
        public IActionResult GetPosts([FromQuery] int IdUser)
        {
            if (IdUser != 0)
            {
                var data = db.UserPosts(IdUser);
                if (data != null)
                {
                    return Ok(data);
                }
                else
                {
                    // return NotFound();
                    return Ok(new List<object>());
                }
            }
            else
            {
                // return BadRequest();
                return Ok(new List<object>());
            }
        }
        [HttpGet("{id}")]
        [ActionName("GetInfo")]
        public IActionResult GetInfo(int id)
        {
            var data = db.GetUser(id);
            if (data != null)
            {
                return Ok(data);
            }
            else
            {
               // return NotFound();
                 return Ok(new List<object>());
            }
        }
    }
}
