using GraduationProjectAPI.Infrastructure;
using GraduationProjectAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProjectAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookLibraryController : Controller
    {
        private readonly IBookLibrarycs db;
        public BookLibraryController(IBookLibrarycs _db)
        {
            db = _db;
        }
        [HttpGet]
        public IActionResult GetBookLibraries()
        {
            IQueryable<BookLibrary> data = db.GetBookLibraries;
            return Ok(data);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = db.GetBookLibrary(id);
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
        public IActionResult AddBookLibrary([FromBody] BookLibrary bookLibrary)
        {
            if (bookLibrary == null)
            {
                //  return BadRequest();
                 return Ok(new List<object>());
            }
            else
            {
               var data= db.Save(bookLibrary);
                return Ok(data);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] BookLibrary bookLibrary)
        {
            if (bookLibrary == null || bookLibrary.Id == 0)
            {
                //  return BadRequest();
                 return Ok(new List<object>());
            }
            else
            {
                db.Update(bookLibrary);
                return Ok();
            }
        }
        [HttpDelete]
        public IActionResult Delete([FromBody] BookLibrary bookLibrary)
        {
            db.Delete(bookLibrary);
            return Ok();
        }
        [HttpGet]
        [ActionName("GetIdLibraryBook")]
        public IActionResult GetIdLibraryBook([FromQuery] int IdBook,[FromQuery] int IdLibrary)
        {
            if(IdBook != 0 && IdLibrary != 0)
            {
                var data = db.GetIdLibraryBook(IdBook, IdLibrary);
                if(data != 0)
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
                //  return BadRequest();
                return Ok(new List<object>());
            }
        }
    }
}
