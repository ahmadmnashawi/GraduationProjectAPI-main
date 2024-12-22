using GraduationProjectAPI.Infrastructure;
using GraduationProjectAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace GraduationProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : Controller
    {
        private readonly IAnswer db;
        public AnswerController(IAnswer _db)
        {
            db = _db;
        }
        [HttpGet]
        public IActionResult GetAnswers()
        {
            IQueryable<Answer> data = db.GetAnswers;
            return Ok(data);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = db.GetAnswer(id);
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
        public IActionResult AddAnswer([FromBody] Answer answer)
        {
            if (answer == null)
            {
                //  return BadRequest();
                return Ok(new List<object>());
            }
            else
            {
                db.Save(answer);
                return Ok();
            }
        }
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Answer answer)
        {
            if (answer == null || answer.Id == 0)
            {
                //  return BadRequest();
                return Ok(new List<object>());
            }
            else
            {
                db.Update(answer);
                return Ok();
            }
        }
        [HttpDelete]
        public IActionResult Delete([FromQuery] Answer answer)
        {
            db.Delete(answer);
            return Ok();
        }
    }
}
