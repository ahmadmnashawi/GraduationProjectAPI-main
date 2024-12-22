using GraduationProjectAPI.Model;
using GraduationProjectAPI.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProjectAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReferenceController : Controller
    {
        private readonly IReference db;
        public ReferenceController(IReference _db)
        {
            db = _db;
        }
        [HttpGet]
        public IActionResult GetReferences()
        {
            IQueryable<Reference> data = db.GetReferences;
            return Ok(data);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = db.GetReference(id);
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
        public IActionResult AddReference([FromBody] Reference reference)
        {
            if (reference == null)
            {
               // return BadRequest();
                return Ok(new List<object>());
            }
            else
            {
               var data= db.Save(reference);
                return Ok(data);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Reference reference)
        {
            if (reference == null || reference.Id == 0)
            {
               // return BadRequest();
                return Ok(new List<object>());
            }
            else
            {
                db.Update(reference);
                return Ok();
            }
        }
        [HttpDelete]
        public IActionResult Delete([FromBody] Reference reference)
        {
            db.Delete(reference);
            return Ok();
        }
        [HttpGet]
        [ActionName("GetReferenceContent")]
        public IActionResult GetReferenceContent()
        {
            var data = db.GetRefrencesContent();
            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                //return NotFound();
                return Ok(new List<object>());
            }
        }
        [HttpGet]
        [ActionName("GetReferenceLink")]
        public IActionResult GetReferenceLink([FromQuery] int IdContent)
        {
            if (IdContent != 0)
            {
                var data = db.GetRefrenceLink(IdContent);
                if (data != null)
                {
                    return Ok(data);
                }
                else
                {
                    //return NotFound();
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
        [ActionName("GetAllRefrencesAdmins")]
        public IActionResult GGetAllRefrencesAdmins()
        {
            
                var data = db.GetAllRefrencesAdmins();
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
        [HttpGet]
        [ActionName("GetRefrencesAdmins")]
        public IActionResult GetRefrencesAdmins([FromQuery] int idUser)
        {
            if (idUser != 0)
            {
                var data = db.GetRefrenceByAdmin(idUser);
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
    }
}
