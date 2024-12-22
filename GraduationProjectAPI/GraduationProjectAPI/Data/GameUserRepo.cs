using GraduationProjectAPI.Infrastructure;
using GraduationProjectAPI.Model;
namespace GraduationProjectAPI.Data
{
    public class GameUserRepo:IGameUser
    {
        private readonly GraduationProjectDbContext _db;
        public GameUserRepo(GraduationProjectDbContext db)
        {
            _db = db;
        }
        public IQueryable<GameUser> GetGameUsers => _db.GameUsers;

        public void Delete(GameUser GameUser)
        {
            var gameUser = _db.GameUsers.FirstOrDefault(p => p.Id == GameUser.Id);
            if (gameUser != null)
            {
                _db.GameUsers.Remove(gameUser);
                _db.SaveChanges();
            }


        }
        public GameUser GetGameUser(int id)
        {
            var gameUser = _db.GameUsers.FirstOrDefault(p => p.Id == id);
            if (gameUser != null)
                return gameUser;
            else
                return null;

        }
        public void Save(GameUser gameUser)
        {
            if (gameUser.Id == 0)
            {
                _db.GameUsers.Add(gameUser);
                _db.SaveChanges();
            }

        }
        public void Update(GameUser gameUser)
        {
            var GameUser = _db.GameUsers.FirstOrDefault(p => p.Id == gameUser.Id);
            if (GameUser != null)
            {
                GameUser.IdGame = gameUser.IdGame;
                GameUser.IdUser = gameUser.IdUser;
                GameUser.userLevel = gameUser.userLevel;
                GameUser.Score = gameUser.Score;
                _db.SaveChanges();
            }
        }
    }
}
