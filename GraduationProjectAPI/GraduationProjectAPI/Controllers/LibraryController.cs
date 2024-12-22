using GraduationProjectAPI.Model;
using GraduationProjectAPI.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProjectAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LibraryController : Controller
    {
        private readonly ILibrary db;
        public LibraryController(ILibrary _db)
        {
            db = _db;
        }
        [HttpGet]
        public IActionResult GetLibraries()
        {
            IQueryable<Library> data = db.GetLibraries;
            return Ok(data);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = db.GetLibrary(id);
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
        public IActionResult AddLibrary([FromBody] Library library)
        {
            if (library == null)
            {
               // return BadRequest();
                return Ok(new List<object>());
            }
            else
            {
               var data= db.Save(library);
                return Ok(data);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Library library)
        {
            if (library == null || library.Id == 0)
            {
               // return BadRequest();
               return Ok(new List<object>());
            }
            else
            {
                db.Update(library);
                return Ok();
            }
        }
        [HttpDelete]
        public IActionResult Delete([FromQuery] Library library)
        {
            db.Delete(library);
            return Ok();
        }
        [HttpGet]
        [ActionName("GetLibraryBook")]
        public IActionResult GetLibraryBook([FromQuery] int IdLibrary)
        {
            if(IdLibrary != 0)
            {
                var data = db.GetBookLibrary(IdLibrary);
                if(data != null)
                {
                    return Ok(data);
                }
                else
                {
                    return Ok(new List<object>());
                }
            }
            else
            {
                //return BadRequest();
                return Ok(new List<object>());
            }
        }
        [HttpGet]
        [ActionName("GetBookWriters")]
        public IActionResult GetBookWriters([FromQuery] int IdLibrary,[FromQuery] int IdWriter)
        {
            if(IdLibrary != 0 && IdWriter !=0)
            {
                var data = db.GetBookWriters(IdLibrary, IdWriter);
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
              //  return BadRequest();
                return Ok(new List<object>());
            }
        }
        [HttpGet]
        [ActionName("GetBookType")]
        public IActionResult GetBookType([FromQuery] int IdLibrary,[FromQuery] int IdType)
        {
            if(IdLibrary != 0 && IdType !=0)
            {
                var data = db.GetBookType(IdLibrary, IdType);
                if(data != null)
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
        [HttpGet]
        [ActionName("GetLibraryBookType")]
        public IActionResult GetLibraryBookType([FromQuery] int IdLibrary)
        {
            if(IdLibrary != 0)
            {
                var data = db.GetLibraryBookType(IdLibrary);
                if(data != null)
                {
                    return Ok(data);
                }
                else
                {
                    return NotFound();
                    return Ok(new List<object>());
                }
            }
            else
            {
                //return BadRequest();
                return Ok(new List<object>());
            }
        }
        [HttpGet]
        [ActionName("GetBookByName")]
        public IActionResult GetBookByName([FromQuery]int IdLibrary,[FromQuery] string searh)
        {
            if(IdLibrary !=0 && searh != null)
            {
                var data = db.GetBookByName(IdLibrary, searh);
                if(data != null)
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
        [HttpGet]
        [ActionName("GetBookTypeSearch")]
        public IActionResult GetBookTypeSearch([FromQuery]int IdLibrary,[FromQuery] string search)
        {
            if(IdLibrary !=0 && search != null)
            {
                var data = db.GetBookTypeSearch(IdLibrary, search);
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
                //  return BadRequest();
                return Ok(new List<object>());
            }
        }
        [HttpGet]
        [ActionName("GetBookWritersSearch")]
        public IActionResult GetBookWritersSearch([FromQuery] int IdLibrary, [FromQuery] string search)
        {
            if (IdLibrary != 0 && search != null)
            {
                var data = db.GetBookWritersSearch(IdLibrary, search);
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
                //  return BadRequest();
                return Ok(new List<object>());
            }
        }
    }
}
