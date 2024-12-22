using GraduationProjectAPI.Model;
using GraduationProjectAPI.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProjectAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommentsController : Controller
    {
        private readonly IComments db;
        public CommentsController(IComments _db)
        {
            db = _db;
        }
        [HttpGet]
        public IActionResult GetComments()
        {
            IQueryable<Comments> data = db.GetComments;
            return Ok(data);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = db.GetComment(id);
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
        public IActionResult AddComment([FromBody] Comments comment)
        {
            if (comment == null)
            {
                //  return BadRequest();
                return Ok(new List<object>());
            }
            else
            {
                db.Save(comment);
                return Ok();
            }
        }
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Comments comment)
        {
            if (comment == null || comment.Id == 0)
            {
                //  return BadRequest();
                 return Ok(new List<object>());
            }
            else
            {
                db.Update(comment);
                return Ok();
            }
        }
        [HttpDelete]
        public IActionResult Delete([FromQuery]Comments comments)
        {
            db.Delete(comments);
            return Ok();
        }
        [HttpGet]
        [ActionName("PostComment")]
        public IActionResult PostComment([FromQuery] int IdPost)
        {
            if(IdPost != 0)
            {
                var data = db.PostComments(IdPost);
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
        [ActionName("PostCommentDto")]
        public IActionResult PostCommentDto([FromQuery] int IdPost)
        {
            if (IdPost != 0)
            {
                var data = db.commentDtos(IdPost);
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
    }
}
