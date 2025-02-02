using GraduationProjectAPI.Infrastructure;
using GraduationProjectAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace GraduationProjectAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SearchController : Controller
    {
        private readonly ISearch db;
        public SearchController(ISearch _db)
        {
            db = _db;
        }
        [HttpGet]
        [ActionName("Search")]
        public IActionResult Search([FromQuery]string search,[FromQuery] int IdUser)
        {
            if (search != null || IdUser != 0)
            {
                var data = db.Search(search, IdUser);
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
        [ActionName("SearchUsers")]
        public IActionResult SearchUsers([FromQuery] string search, [FromQuery] int IdUser)
        {
            if (search != null)
            {
                var data = db.SearchUser(search, IdUser);
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
        [ActionName("SearchGroups")]
        public IActionResult SearchGroups([FromQuery] string search, [FromQuery] int IdUser)
        {
            if (search != null)
            {
                var data = db.SearchGroup(search, IdUser);
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
        [ActionName("SearchContent")]
        public IActionResult SearchContent([FromQuery] string search, [FromQuery] int IdUser)
        {
            if (search != null)
            {
                var data = db.SearchContent(search, IdUser);
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
        [HttpGet]
        [ActionName("SearchLibrary")]
        public IActionResult SearchLibrary([FromQuery] string search, [FromQuery] int IdUser)
        {
            if (search != null)
            {
                var data = db.SearchLibrary(search, IdUser);
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
        [ActionName("SearchComplaint")]
        public IActionResult SearchComplaint([FromQuery] string search,[FromQuery] int IdUser)
        {
            if (search != null)
            {
                var data = db.SearchComplaint(search, IdUser);
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
        [HttpGet]
        [ActionName("SearchReferance")]
        public IActionResult SearchReferance([FromQuery] string search, [FromQuery] int IdUser)
        {
            if (search != null)
            {
                var data = db.SearchReferance(search, IdUser);
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
        [ActionName("SearchBook")]
        public IActionResult SearchBook([FromQuery] string search, [FromQuery] int IdUser)
        {
            if (search != null)
            {
                var data = db.SearchBook(search, IdUser);
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
        [HttpGet]
        [ActionName("SearchWriter")]
        public IActionResult SearchWriter([FromQuery] string search, [FromQuery] int IdUser)
        {
            if (search != null)
            {
                var data = db.SearchWriter(search, IdUser);
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
