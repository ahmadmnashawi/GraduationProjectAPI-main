using GraduationProjectAPI.Model;
namespace GraduationProjectAPI.Infrastructure
{
    public interface IPost
    {
        public Post GetPost(int id);
        public IQueryable<Post> GetPosts { get; }
        public void Save(Post post);
        public void Update(Post post);
        public void Delete(Post post);
    }
}
