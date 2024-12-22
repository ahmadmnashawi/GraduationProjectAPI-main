using GraduationProjectAPI.Infrastructure;
using GraduationProjectAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProjectAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserAccessibilityController : Controller
    {
        private readonly IUserAccessibility db;
        public UserAccessibilityController(IUserAccessibility _db)
        {
            db = _db;
        }
        [HttpGet]
        public IActionResult GetUserAccessibilities()
        {
            IQueryable<UserAccessibility> data = db.GetUserAccessibilities;
            return Ok(data);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = db.GetUserAccessibility(id);
            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                //  return NotFound();
                return Ok(new List<object>());
            }
        }
        [HttpPost]
        public IActionResult AddUserAccessibility([FromBody] UserAccessibility userAccessibility)
        {
            if (userAccessibility == null)
            {
                //  return BadRequest();
                return Ok(new List<object>());
            }
            else
            {
               var data= db.Save(userAccessibility);
                return Ok(data);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] UserAccessibility userAccessibility)
        {
            if (userAccessibility == null || userAccessibility.Id == 0)
            {
                //  return BadRequest();
                return Ok(new List<object>());
            }
            else
            {
                db.Update(userAccessibility);
                return Ok();
            }
        }
        [HttpDelete]
        public IActionResult Delete([FromQuery] UserAccessibility userAccessibility)
        {
            db.Delete(userAccessibility);
            return Ok();
        }
        [HttpGet]
        [ActionName("GetUserAccessibilites")]
        public IActionResult GetUserAccessibilites([FromQuery] int IdUser)
        {
            if(IdUser != 0)
            {
                var data = db.getUserAccessibilities(IdUser);
                if(data != null)
                {
                    return Ok(data);
                }
                else
                {
                    return Ok(new List<object>());
                 //   return NotFound();
                }
            }
            else
            {
               // return BadRequest();
                return Ok(new List<object>());
            }
        }
    }
}
