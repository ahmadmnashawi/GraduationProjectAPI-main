using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using GraduationProjectAPI.Infrastructure;
using GraduationProjectAPI.Data;
using GraduationProjectAPI.Model;
namespace GraduationProjectAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContentController : Controller
    {
        private readonly IContent db;
        public ContentController(IContent _db)
        {
            db = _db;
        }
        [HttpGet]
        public IActionResult GetContents()
        {
            IQueryable<Content> data = db.GetContents;
            return Ok(data);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = db.GetContent(id);
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
        public IActionResult AddType([FromBody] Content type)
        {
            if (type == null)
            {
               // return BadRequest();
                 return Ok(new List<object>());
            }
            else
            {
               var data= db.Save(type);
                return Ok(data);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Content type)
        {
            if (type == null || type.Id == 0)
            {
               // return BadRequest();
                 return Ok(new List<object>());
            }
            else
            {
                db.Update(type);
                return Ok();
            }
        }
        [HttpDelete]
        public IActionResult Delete([FromQuery] Content content)
        {
            db.Delete(content);
            return Ok();
        }
    }
}
