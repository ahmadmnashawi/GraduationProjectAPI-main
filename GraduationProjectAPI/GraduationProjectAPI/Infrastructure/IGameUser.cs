using GraduationProjectAPI.Model;
namespace GraduationProjectAPI.Infrastructure
{
    public interface IGameUser
    {
        public GameUser GetGameUser(int id);
        public IQueryable<GameUser> GetGameUsers { get; }
        public void Save(GameUser gameUser);
        public void Update(GameUser gameUser);
        public void Delete(GameUser gameUser);
    }
}
