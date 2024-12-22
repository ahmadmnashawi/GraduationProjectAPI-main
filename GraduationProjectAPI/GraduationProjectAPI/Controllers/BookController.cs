using GraduationProjectAPI.Infrastructure;
using GraduationProjectAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProjectAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IBook db;
        public BookController(IBook _db)
        {
            db = _db;
        }
        [HttpGet]
        public IActionResult GetBooks()
        {
            IQueryable<Book> data = db.GetBooks;
            return Ok(data);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = db.GetBook(id);
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
        public IActionResult AddBook([FromBody] Book book)
        {
            if (book == null)
            {
                //  return BadRequest();
                return Ok(new List<object>());
            }
            else
            {
                db.Save(book);
                return Ok();
            }
        }
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Book book)
        {
            if (book == null || book.Id == 0)
            {
                //  return BadRequest();
                return Ok(new List<object>());
            }
            else
            {
                db.Update(book);
                return Ok();
            }
        }
        [HttpDelete]
        public IActionResult Delete([FromQuery] Book book)
        {
            db.Delete(book);
            return Ok();
        }
        [HttpGet]
        [ActionName("GetBookDetails")]
        public IActionResult GetBookDetails([FromQuery] int IdBook)
        {
            if(IdBook != 0)
            {

                var data = db.BookDetails(IdBook);
                if(data != null)
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
        [HttpGet]
        [ActionName("GetBookId")]
        public IActionResult GetBookId([FromQuery] string name)
        {
            if(name != null)
            {
                var data = db.GetBookId(name);
                if (data != 0)
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
        [HttpGet]
        [ActionName("GetBookWriters")]
        public IActionResult GetBookWriters([FromQuery] int IdBook)
        {
            if (IdBook != 0)
            {
                var data = db.GetBookWriters(IdBook);
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
            else
            {
                // return BadRequest();
                return Ok(new List<object>());
            }
        }
    }
}
