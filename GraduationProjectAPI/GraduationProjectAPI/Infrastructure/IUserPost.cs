using GraduationProjectAPI.Model;
namespace GraduationProjectAPI.Infrastructure
{
    public interface IUserPost
    {
        public UserPost GetUserPost(int id);
        public IQueryable<UserPost> GetUserPosts { get; }
        public bool Save(UserPost userPost);
        public void Update(UserPost userPost);
        public void Delete(UserPost userPost);
    }
}
