using GraduationProjectAPI.Model;
using GraduationProjectAPI.Infrastructure;
namespace GraduationProjectAPI.Data
{
    public class PostRepo:IPost
    {
        private readonly GraduationProjectDbContext _db;
        public PostRepo(GraduationProjectDbContext db)
        {
            _db = db;
        }
        public IQueryable<Post> GetPosts => _db.Posts;

        public void Delete(Post Post)
        {
            var post = _db.Posts.FirstOrDefault(p => p.Id == Post.Id);
            if (post != null)
            {
                var comment = _db.Comments.Where(p => p.IdPost == post.Id).ToList();
                var userPost = _db.UserPosts.Where(p => p.IdPost == post.Id).ToList();
                if(comment.Count != 0)
                {
                    _db.Comments.RemoveRange(comment);
                    _db.SaveChanges();
                }
                if (userPost.Count != 0)
                {
                    _db.UserPosts.RemoveRange(userPost);
                    _db.SaveChanges();
                }
                _db.Posts.Remove(post);
                _db.SaveChanges();
            }


        }
        public Post GetPost(int id)
        {
            var post = _db.Posts.FirstOrDefault(p => p.Id == id);
            if (post != null)
                return post;
            else
                return null;

        }
        public void Save(Post post)
        {
            if (post.Id == 0)
            {
                _db.Posts.Add(post);
                _db.SaveChanges();
            }

        }
        public void Update(Post post)
        {
            var Post = _db.Posts.FirstOrDefault(p => p.Id == post.Id);
            if (Post != null)
            {
                Post.dateTime = post.dateTime;
                Post.Description = post.Description;
                Post.Image = post.Image;
                Post.IdContent = post.IdContent;
                Post.IdUser = post.IdUser;
                post.IdGroup = post.IdGroup;
                _db.SaveChanges();
            }
        }
    }
}
