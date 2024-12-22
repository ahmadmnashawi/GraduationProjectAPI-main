using GraduationProjectAPI.Infrastructure;
using GraduationProjectAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace GraduationProjectAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccessibilityController : Controller
    {
        private readonly IAccessibility db;
        public AccessibilityController(IAccessibility _db)
        {
            db = _db;
        }
        [HttpGet]
        public IActionResult GetAccessibilities()
        {
            IQueryable<Accessibility> data = db.GetAccessibilties;
            return Ok(data);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = db.GetAccessibility(id);
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
        public IActionResult AddAccessibility([FromBody] Accessibility accessibility)
        {
            if (accessibility == null)
            {
                //  return BadRequest();
                return Ok(new List<object>());
            }
            else
            {
               var data= db.Save(accessibility);
                if (data != false)
                    return Ok(data);
                else return Ok(data);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Accessibility accessibility)
        {
            if (accessibility == null || accessibility.Id == 0)
            {
                //  return BadRequest();
                return Ok(new List<object>());
            }
            else
            {
                db.Update(accessibility);
                return Ok();
            }
        }
        [HttpDelete]
        public IActionResult Delete([FromBody] Accessibility accessibility)
        {
            db.Delete(accessibility);
            return Ok();
        }
        [HttpGet]
        [ActionName("DeleteUserAccessibility")]
        public IActionResult DeleteUserAccessibility([FromQuery] int IdUser,[FromQuery] string access)
        {
            if(IdUser != 0 && access != null)
            {
                var data = db.DeleteUserAccessibility(IdUser, access);
                if(data != false)
                {
                    return Ok(data);
                }
                else
                {
                    return Ok(new List<object>());
                  //  return NotFound();
                }
            }
            else
            {
                return Ok(new List<object>());
              //  return BadRequest();
            }
        }
    }
}
