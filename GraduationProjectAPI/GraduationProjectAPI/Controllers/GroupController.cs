using GraduationProjectAPI.Model;
using GraduationProjectAPI.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProjectAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GroupController : Controller
    {
        private readonly IGroup db;
        public GroupController(IGroup _db)
        {
            db = _db;
        }
        [HttpGet]
        [ActionName("GetGroups")]
        public IActionResult GetGroups()
        {
            IQueryable<Group> data = db.GetGroups;
            return Ok(data);
        }
        [HttpGet("{id}")]
        [ActionName("Get")]
        public IActionResult Get(int id)
        {
            var data = db.GetGroup(id);
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
        [HttpPost]
        [ActionName("AddGroup")]
        public IActionResult AddGroup([FromBody] Group group)
        {
            if (group == null)
            {
              //  return BadRequest();
                return Ok(new List<object>());
            }
            else
            {
               var data= db.Save(group);
                return Ok(data);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Group group)
        {
            if (group == null || group.Id == 0)
            {
               // return BadRequest();
                return Ok(new List<object>());
            }
            else
            {
                db.Update(group);
                return Ok();
            }
        }
        [HttpDelete]
        [ActionName("Delete")]
        public IActionResult Delete([FromQuery] int group)
        {
            db.Delete(group);
            return Ok();
        }
        [HttpGet]
        [ActionName("GetGroupPosts")]
        public IActionResult GetGroupPosts([FromQuery] int IdGroup,[FromQuery] int IdUser)
        {
            if (IdGroup != 0)
            {
                var data = db.GroupPost(IdGroup, IdUser);
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
        [ActionName("GetGroupMembers")]
        public IActionResult GetGroupMembers([FromQuery] int IdGroup)
        {
            if (IdGroup != 0)
            {
                var data = db.GetGroupMembers(IdGroup);
                if (data != null)
                {
                    return Ok(data);
                }
                else
                {
                    //return NotFound();
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
        [ActionName("UserExisitInGroup")]
        public IActionResult UserExisitInGroup([FromQuery] int IdUser,[FromQuery] int IdGroup)
        {
            if(IdUser != 0 && IdGroup != 0)
            {
                var data = db.ExisitInGroup(IdUser, IdGroup);
                if(data != false)
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
    }
}
