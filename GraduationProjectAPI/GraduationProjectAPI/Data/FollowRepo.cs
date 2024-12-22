using GraduationProjectAPI.Infrastructure;
using GraduationProjectAPI.Model;
namespace GraduationProjectAPI.Data
{
    public class FollowRepo : IFollow
    {
        private readonly GraduationProjectDbContext _db;
        public FollowRepo(GraduationProjectDbContext db)
        {
            _db = db;
        }
        public IQueryable<Follow> GetFollows => _db.Follows;

        public void Delete(Follow Follow)
        {
            var follow = _db.Follows.FirstOrDefault(p => p.Id == Follow.Id);
            if (follow != null)
            {
                _db.Follows.Remove(follow);
                _db.SaveChanges();
            }


        }
        public Follow GetFollow(int id)
        {
            var follow = _db.Follows.FirstOrDefault(p => p.Id == id);
            if (follow != null)
                return follow;
            else
                return null;

        }
        public bool Save(Follow follow)
        {
            if (follow.Id == 0)
            {
                if(!IsExisting(follow))
                {
                    _db.Follows.Add(follow);
                    _db.SaveChanges();
                    return true;
                }
              
            }
            return false;
        }
        public void Update(Follow follow)
        {
            var Follow = _db.Follows.First(p => p.Id == follow.Id);
            if (Follow != null)
            {
                Follow.followedId = follow.followedId;
                Follow.followId = follow.followId;
                _db.SaveChanges();
            }
        }
        public bool IsExisting(Follow follow)
        {
            var data = _db.Follows.Any(p => p.followedId == follow.followedId && p.followId == follow.followId);
            if(data != true)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
