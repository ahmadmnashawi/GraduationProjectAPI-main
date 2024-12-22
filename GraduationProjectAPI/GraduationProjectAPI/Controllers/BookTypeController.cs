using GraduationProjectAPI.Model;
using GraduationProjectAPI.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookTypeController : Controller
    {
        private readonly IBookType db;
        public BookTypeController(IBookType _db)
        {
            db = _db;
        }
        [HttpGet]
        public IActionResult GetBookTypes()
        {
            IQueryable<BookType> data = db.GetBookTypes;
            return Ok(data);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = db.GetBookType(id);
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
        public IActionResult AddBookType([FromBody] BookType bookType)
        {
            if (bookType == null)
            {
                // return BadRequest();
                return Ok(new List<object>());
            }
            else
            {
                db.Save(bookType);
                return Ok();
            }
        }
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] BookType bookType)
        {
            if (bookType == null || bookType.Id == 0)
            {
                // return BadRequest();
                return Ok(new List<object>());
            }
            else
            {
                db.Update(bookType);
                return Ok();
            }
        }
        [HttpDelete]
        public IActionResult Delete([FromQuery] int id)
        {
            db.Delete(id);
            return Ok();
        }
    }
}
