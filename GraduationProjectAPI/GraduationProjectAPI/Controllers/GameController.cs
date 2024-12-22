using GraduationProjectAPI.Model;
using GraduationProjectAPI.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProjectAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GameController : Controller
    {
        private readonly IGame db;
        public GameController(IGame _db)
        {
            db = _db;
        }
        [HttpGet]
        public IActionResult GetGames()
        {
            IQueryable<Game> data = db.GetGames;
            return Ok(data);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = db.GetGame(id);
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
        public IActionResult AddGame([FromBody] Game game)
        {
            if (game == null)
            {
               // return BadRequest();
                return Ok(new List<object>());
            }
            else
            {
               var data= db.Save(game);
                return Ok(data);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Game game)
        {
            if (game == null || game.Id == 0)
            {
               // return BadRequest();
                return Ok(new List<object>());
            }
            else
            {
                db.Update(game);
                return Ok();
            }
        }
        [HttpDelete]
        public IActionResult Delete([FromQuery] Game game)
        {
            db.Delete(game);
            return Ok();
        }
        [HttpGet]
        [ActionName("GetGameWithUserScore")]
        public IActionResult GetGameWithUserScore([FromQuery] int IdUser)
        {
            var data = db.GetGamesWithScore(IdUser);
            if(data != null)
            {
                return Ok(data);
            }
            else
            {
                return Ok(new List<object>());
              //  return BadRequest();
            }
        }
        [HttpGet]
        [ActionName("GetUserGameLevels")]
        public IActionResult GetUserGameLevels([FromQuery] int IdUser,[FromQuery] int IdGame)
        {
            if (IdUser != 0 && IdGame != 0)
            {
                var data = db.GetUserGameLevels(IdUser,IdGame);
                if (data != null)
                {
                    return Ok(data);
                }
                else
                {
                    return Ok(new List<object>());
                   // return NotFound();
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
