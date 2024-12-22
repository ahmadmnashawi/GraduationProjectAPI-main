using GraduationProjectAPI.Model;
using GraduationProjectAPI.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowController : Controller
    {
        private readonly IFollow db;
        public FollowController(IFollow _db)
        {
            db = _db;
        }
        [HttpGet]
        public IActionResult GetFollows()
        {
            IQueryable<Follow> data = db.GetFollows;
            return Ok(data);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = db.GetFollow(id);
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
        public IActionResult AddFollow([FromBody] Follow follow)
        {
            if (follow == null)
            {
               // return BadRequest();
                return Ok(new List<object>());
            }
            else
            {
               var data= db.Save(follow);
                return Ok(data);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Follow follow)
        {
            if (follow == null || follow.Id == 0)
            {
               // return BadRequest();
                return Ok(new List<object>());
            }
            else
            {
                db.Update(follow);
                return Ok();
            }
        }
        [HttpDelete]
        public IActionResult Delete([FromQuery] Follow follow)
        {
            db.Delete(follow);
            return Ok();
        }
    }
}
