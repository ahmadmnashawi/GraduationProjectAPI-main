using Microsoft.AspNetCore.Mvc;
using GraduationProjectAPI.Infrastructure;
using GraduationProjectAPI.Model;
using GraduationProjectAPI.Data;
namespace GraduationProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserGroupController : Controller
    {
        private readonly IUserGroup db;
        public UserGroupController(IUserGroup _db)
        {
            db = _db;
        }
        [HttpGet]
        public IActionResult GetUserGroups()
        {
            IQueryable<UserGroup> data = db.GetUserGroups;
            return Ok(data);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = db.GetUserGroup(id);
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
        public IActionResult AddUserGroup([FromBody] UserGroup userGroup)
        {
            if (userGroup == null)
            {
                //  return BadRequest();
                return Ok(new List<object>());
            }
            else
            {
              var data= db.Save(userGroup);
                return Ok(data);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Put([FromBody]UserGroup userGroup)
        {
            if (userGroup == null || userGroup.Id == 0)
            {
                //  return BadRequest();
                return Ok(new List<object>());
            }
            else
            {
                db.Update(userGroup);
                return Ok();
            }
        }
        [HttpDelete]
        public IActionResult Delete([FromBody] UserGroup userGroup )
        {
            db.Delete(userGroup);
            return Ok();
        }
    }
}
