using GraduationProjectAPI.Model;
using GraduationProjectAPI.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameUserController : Controller
    {
        private readonly IGameUser db;
        public GameUserController(IGameUser _db)
        {
            db = _db;
        }
        [HttpGet]
        public IActionResult GetGameUsers()
        {
            IQueryable<GameUser> data = db.GetGameUsers;
            return Ok(data);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = db.GetGameUser(id);
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
        [HttpPost]
        public IActionResult AddGameUser([FromBody] GameUser gameUser)
        {
            if (gameUser == null)
            {
              //  return BadRequest();
                return Ok(new List<object>());
            }
            else
            {
                db.Save(gameUser);
                return Ok();
            }
        }
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] GameUser gameUser)
        {
            if (gameUser == null || gameUser.Id == 0)
            {
               // return BadRequest();
                return Ok(new List<object>());
            }
            else
            {
                db.Update(gameUser);
                return Ok();
            }
        }
        [HttpDelete]
        public IActionResult Delete([FromQuery] GameUser gameUser)
        {
            db.Delete(gameUser);
            return Ok();
        }
    }
}
