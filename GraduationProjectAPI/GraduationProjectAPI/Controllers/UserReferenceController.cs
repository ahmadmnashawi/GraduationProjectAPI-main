using GraduationProjectAPI.Model;
using GraduationProjectAPI.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserReferenceController : Controller
    {
        private readonly IUserReference db;
        public UserReferenceController(IUserReference _db)
        {
            db = _db;
        }
        [HttpGet]
        public IActionResult GetUserReferences()
        {
            IQueryable<UserReference> data = db.GetUserReferences;
            return Ok(data);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = db.GetUserReference(id);
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
        public IActionResult AddUserReference([FromBody] UserReference userReference)
        {
            if (userReference == null)
            {
               // return BadRequest();
                return Ok(new List<object>());
            }
            else
            {
               var data= db.Save(userReference);
                return Ok(data);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] UserReference userReference)
        {
            if (userReference == null || userReference.Id == 0)
            {
               // return BadRequest();
                return Ok(new List<object>());
            }
            else
            {
                db.Update(userReference);
                return Ok();
            }
        }
        [HttpDelete]
        public IActionResult Delete([FromQuery] UserReference userReference)
        {
            db.Delete(userReference);
            return Ok();
        }
    }
}
