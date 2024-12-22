using GraduationProjectAPI.Dto;
using GraduationProjectAPI.Infrastructure;
using GraduationProjectAPI.Model;
namespace GraduationProjectAPI.Data
{
    public class GameRepo:IGame
    {
        private readonly GraduationProjectDbContext _db;
        public GameRepo(GraduationProjectDbContext db)
        {
            _db = db;
        }
        public IQueryable<Game> GetGames => _db.Games;

        public void Delete(Game Game)
        {
            var game = _db.Games.FirstOrDefault(p => p.Id == Game.Id);
            if (game != null)
            {
                var gameuser = _db.GameUsers.Where(p => p.IdGame == game.Id).ToList();
                if(gameuser.Count != 0)
                {
                    _db.GameUsers.RemoveRange(gameuser);
                    _db.SaveChanges();
                }
                _db.Games.Remove(game);
                _db.SaveChanges();
            }


        }
        public Game GetGame(int id)
        {
            var game = _db.Games.FirstOrDefault(p => p.Id == id);
            if (game != null)
                return game;
            else
                return null;

        }
        public bool Save(Game game)
        {
            if (game.Id == 0)
            {
                if (!IsExisting(game))
                {
                    _db.Games.Add(game);
                    _db.SaveChanges();
                    return true;
                }
            }
            return false;
        }
        public void Update(Game game)
        {
            var Game = _db.Games.FirstOrDefault(p => p.Id == game.Id);
            if (Game != null)
            {
                Game.GameLevel = game.GameLevel;
                Game.GameName= game.GameName;
                Game.Image = game.Image;
                _db.SaveChanges();
            }
        }
        public bool IsExisting(Game game)
        {
            var data = _db.Games.Any(p => p.GameName.Equals(game.GameName));
            // var data = _db.Contents.Where(u => string.Equals(u.typeName, content.typeName, StringComparison.CurrentCultureIgnoreCase));
            if (data == false)
            {
                return false;
            }
            else return true;
        }
        public List<GameDto> GetGamesWithScore(int IdUser)
        {
            List<Game> games = _db.Games.ToList();
            List<GameDto> dto = new List<GameDto>();
            var user = _db.Users.FirstOrDefault(p => p.Id == IdUser);
            if (games.Count != 0 && user != null)
            {
                foreach (Game e in games)
                {
                    List<GameUser> gameUsers = _db.GameUsers.Where(p => p.IdGame == e.Id && p.IdUser==IdUser).ToList();
                    GameDto gameDto = new GameDto();
                    if (gameUsers.Count != 0)
                    {
                        gameDto.Game = e;
                        gameDto.GameUser = gameUsers;
                    }
                    else
                    {
                        gameDto.Game = e;
                        gameDto.GameUser = null;
                    }
                    if (!dto.Contains(gameDto))
                    {
                        dto.Add(gameDto);
                    }
                }
                if (dto.Count != 0)
                {
                    return dto;
                }
                return null;
            }
            else return null;
        }
        public GameDto GetUserGameLevels(int IdUser, int IdGame)
        {
            var user = _db.Users.FirstOrDefault(p => p.Id == IdUser);
            var game = _db.Games.FirstOrDefault(p => p.Id == IdGame);
            if(user != null && game != null)
            {
                List<GameUser> gameUsers = _db.GameUsers.Where(p => p.IdGame == game.Id && p.IdUser == user.Id).ToList();
                if(gameUsers.Count != 0)
                {
                    GameDto gameDto = new GameDto();
                    gameDto.Game = game;
                    gameDto.GameUser = gameUsers;
                    return gameDto;
                }
                else
                {
                    GameDto gameDto = new GameDto();
                    gameDto.Game = game;
                    gameDto.GameUser = null;
                    return gameDto;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
