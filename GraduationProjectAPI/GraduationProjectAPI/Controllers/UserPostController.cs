using GraduationProjectAPI.Model;
using GraduationProjectAPI.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPostController : Controller
    {
        private readonly IUserPost db;
        public UserPostController(IUserPost _db)
        {
            db = _db;
        }
        [HttpGet]
        public IActionResult GetUserPosts()
        {
            IQueryable<UserPost> data = db.GetUserPosts;
            return Ok(data);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = db.GetUserPost(id);
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
        public IActionResult AddUserPost([FromBody] UserPost userPost)
        {
            if (userPost == null)
            {
               // return BadRequest();
                return Ok(new List<object>());
            }
            else
            {
               var data= db.Save(userPost);
                return Ok(data);
            }
        }
        [HttpPut]
        public IActionResult Put([FromBody] UserPost userPost)
        {
            if (userPost == null || userPost.Id == 0)
            {
               // return BadRequest();
                return Ok(new List<object>());
            }
            else
            {
                db.Update(userPost);
                return Ok();
            }
        }
        [HttpDelete]
        public IActionResult Delete([FromQuery] UserPost userPost)
        {
            db.Delete(userPost);
            return Ok();
        }
    }
}
