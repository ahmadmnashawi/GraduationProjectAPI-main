using GraduationProjectAPI.Model;
using GraduationProjectAPI.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProjectAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUser db;
        public UserController(IUser _db)
        {
            db = _db;
        }
        [HttpGet]
        public IActionResult GetUsers()
        {
            IQueryable<User> data = db.GetUsers;
            return Ok(data);
        }
        
      
        [HttpPost]
        public IActionResult AddUser([FromBody] User user)
        {
            if (user == null)
            {
               // return BadRequest();
                return Ok(new List<object>());
            }
            else
            {
               var data= db.Save(user);
                 return Ok(data);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] User user)
        {
            if (user == null || user.Id == 0)
            {
              //  return BadRequest();
               return Ok(new List<object>());
            }
            else
            {
                db.Update(user);
                return Ok();
            }
        }
        [HttpDelete]
        public IActionResult Delete([FromQuery] User user)
        {
            db.Delete(user);
            return Ok();
        }
        [HttpGet]
        [ActionName("SignIn")]
        public IActionResult SignIn([FromQuery] string email, [FromQuery] string password)
        {
            if (email == null || password == null)
            {
                //  return BadRequest();
                return Ok(new List<object>());
            }
            else
            {
                var data = db.SignIn(email, password);
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
        }
        [HttpPut]
        [ActionName("ChangePassword")]
        public IActionResult ChangePassword([FromQuery] string email, [FromQuery] string password)
        {
            if (email == null || password == null)
            {
                // return BadRequest();
                return Ok(new List<object>());
            }
            else
            {
                if (db.ChangePassword(email, password))
                {
                    return Ok();
                }
                else
                {
                    // return NotFound();
                    return Ok(new List<object>());
                }
            }
        }
    }
       
    }

