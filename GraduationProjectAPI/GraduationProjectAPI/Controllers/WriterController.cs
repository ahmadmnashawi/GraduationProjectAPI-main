using GraduationProjectAPI.Model;
using GraduationProjectAPI.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WriterController : Controller
    {
        private readonly IWriter db;
        public WriterController(IWriter _db)
        {
            db = _db;
        }
        [HttpGet]
        public IActionResult GetWriters()
        {
            IQueryable<Writer> data = db.GetWriters;
            return Ok(data);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = db.GetWriter(id);
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
        public IActionResult AddWriter([FromBody] Writer writer)
        {
            if (writer == null)
            {
               // return BadRequest();
               return Ok(new List<object>());
            }
            else
            {
              var data=  db.Save(writer);
                return Ok(data);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Writer writer)
        {
            if (writer == null || writer.Id == 0)
            {
               // return BadRequest();
               return Ok(new List<object>());
            }
            else
            {
                db.Update(writer);
                return Ok();
            }
        }
        [HttpDelete]
        public IActionResult Delete([FromQuery] Writer writer)
        {
            db.Delete(writer);
            return Ok();
        }
    }
}
