using GraduationProjectAPI.Model;
using GraduationProjectAPI.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProjectAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BuybookController : Controller
    {
        private readonly IBuybook db;
        public BuybookController(IBuybook _db)
        {
            db = _db;
        }
        [HttpGet]
        public IActionResult GetBuybooks()
        {
            IQueryable<Buybook> data = db.GetBuybooks;
            return Ok(data);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = db.GetBuybook(id);
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
        public IActionResult AddBuybook([FromBody] Buybook buybook)
        {
            if (buybook == null)
            {
                //  return BadRequest();
                return Ok(new List<object>());
            }
            else
            {
                db.Save(buybook);
                return Ok();
            }
        }
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Buybook buybook)
        {
            if (buybook == null || buybook.Id == 0)
            {
                // return BadRequest();
                return Ok(new List<object>());
            }
            else
            {
                db.Update(buybook);
                return Ok();
            }
        }
        [HttpDelete]
        public IActionResult Delete([FromQuery] Buybook Buybook)
        {
            db.Delete(Buybook);
            return Ok();
        }
        [HttpGet]
        [ActionName("GetAllbuys")]
        public IActionResult GetAllbuys([FromQuery] int IdLibrary)
        {
            if(IdLibrary !=0)
            {
                var data = db.GetAllBuys(IdLibrary);
                if(data != null)
                {
                    return Ok(data);
                }
                else
                {
                 //   return NotFound();
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
        [ActionName("GetBuyBookDetails")]
        public IActionResult GetBuyBookDetails([FromQuery] int IdLibrary,[FromQuery] int IdUser)
        {
            if(IdLibrary != 0 &&IdUser != 0)
            {

                var data = db.GetBookDetails(IdLibrary, IdUser);
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
        [ActionName("GetBuyBookUser")]
        public IActionResult GetBuyBookUser([FromQuery]  int IdUser)
        {
            if (  IdUser != 0)
            {

                var data = db.GetAllUserBuys(IdUser);
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
