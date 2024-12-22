using GraduationProjectAPI.Infrastructure;
using GraduationProjectAPI.Model;
namespace GraduationProjectAPI.Data
{
    public class UserPostRepo:IUserPost
    {
        private readonly GraduationProjectDbContext _db;
        public UserPostRepo(GraduationProjectDbContext db)
        {
            _db = db;
        }
        public IQueryable<UserPost> GetUserPosts => _db.UserPosts;

        public void Delete(UserPost UserPost)
        {
            var userPost = _db.UserPosts.FirstOrDefault(p => p.Id == UserPost.Id);
            if (userPost != null)
            {
                _db.UserPosts.Remove(userPost);
                _db.SaveChanges();
            }


        }
        public UserPost GetUserPost(int id)
        {
            var userPost = _db.UserPosts.FirstOrDefault(p => p.Id == id);
            if (userPost != null)
                return userPost;
            else
                return null;

        }
        public bool Save(UserPost userPost)
        {
            if (userPost.Id == 0)
            {
                if (!IsExisting(userPost))
                {
                    _db.UserPosts.Add(userPost);
                    _db.SaveChanges();
                    return true;
                }
            }
            return false;
        }
        public void Update(UserPost userPost)
        {
            var UserPost = _db.UserPosts.First(p => p.Id == userPost.Id);
            if (UserPost != null)
            {
                UserPost.IdPost = userPost.IdPost;
                UserPost.IdUser = userPost.IdUser;
                UserPost.Interaction = userPost.Interaction;
                _db.SaveChanges();
            }
        }
        public bool IsExisting(UserPost userPost)
        {
            var data = _db.UserPosts.Any(p => p.IdUser == userPost.IdUser && p.IdPost == userPost.IdPost);
            if (data != false)
            {
                return true;
            }
            else return false;
        }
    }
}
