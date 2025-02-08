using GraduationProjectAPI.Model;
using GraduationProjectAPI.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProjectAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookWriterController : Controller
    {
        private readonly IBookWriter db;
        public BookWriterController(IBookWriter _db)
        {
            db = _db;
        }
        [HttpGet]
        public IActionResult GetBookWriters()
        {
            IQueryable<BookWriter> data = db.GetBookWriters;
            return Ok(data);
        }
        [HttpGet("{id}")]
        [ActionName("GetBookAllWriter")]
        public IActionResult GetBookAllWriter(int id)
        {
            var data = db.GetBookAllWriter(id);
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

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = db.GetBookWriter(id);
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
        public IActionResult AddBookWriter([FromBody] BookWriter bookWriter)
        {
            if (bookWriter == null)
            {
                // return BadRequest();
                return Ok(new List<object>());
            }
            else
            {
               var data= db.Save(bookWriter);
                return Ok(data);
            }
        }
        [HttpPut]
        public IActionResult Put([FromQuery]  int idBook, [FromQuery] int IdWriter, [FromQuery] bool toDelete)
        {
            if (idBook == 0 && IdWriter == 0)
            {

                return Ok(new List<object>());
            }
            else
            {
                db.Update(idBook,IdWriter,toDelete);
                return Ok();
            }
        }
        [HttpDelete]
        public IActionResult Delete([FromQuery] BookWriter bookWriter)
        {
            db.Delete(bookWriter);
            return Ok();
        }
    }
}
