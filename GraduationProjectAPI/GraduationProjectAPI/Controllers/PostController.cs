using GraduationProjectAPI.Model;
using GraduationProjectAPI.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProjectAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostController : Controller
    {
        private readonly IPost db;
        public PostController(IPost _db)
        {
            db = _db;
        }
        [HttpGet]
        [ActionName("GetPosts")]
        public IActionResult GetPosts()
        {
            IQueryable<Post> data = db.GetPosts;
            return Ok(data);
        }
        [HttpGet("{id}")]
        [ActionName("GetPost")]
        public IActionResult GetPost(int id)
        {
            var data = db.GetPost(id);
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
        [HttpPost]
        [ActionName("AddPost")]
        public IActionResult AddPost([FromBody] Post post)
        {
            if (post == null)
            {
               // return BadRequest();
               return Ok(new List<object>());
            }
            else
            {
                db.Save(post);
                return Ok();
            }
        }
        [HttpPut("{id}")]
        [ActionName("UpdatePost")]
        public IActionResult UpdatePost([FromBody] Post post)
        {
            if (post == null || post.Id == 0)
            {
               // return BadRequest();
                return Ok(new List<object>());
            }
            else
            {
                db.Update(post);
                return Ok();
            }
        }
        [HttpDelete]
        public IActionResult Delete([FromQuery] Post post)
        {
            db.Delete(post);
            return Ok();
        }
    }
}
