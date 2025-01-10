using GraduationProjectAPI.Infrastructure;
using GraduationProjectAPI.Model;
using GraduationProjectAPI.Dto;
using Microsoft.EntityFrameworkCore;

namespace GraduationProjectAPI.Data
{
    public class CommentsRepo :IComments
    {
        private readonly GraduationProjectDbContext _db;
        public CommentsRepo(GraduationProjectDbContext db)
        {
            _db = db;
        }
        public IQueryable<Comments> GetComments => _db.Comments;

        public void Delete(Comments Comment)
        {
            var commet = _db.Comments.FirstOrDefault(p => p.Id == Comment.Id);
            if (commet != null)
            {
                _db.Comments.Remove(commet);
                _db.SaveChanges();
            }


        }
        public Comments GetComment(int id)
        {
            var comment = _db.Comments.FirstOrDefault(p => p.Id == id);
            if (comment != null)
                return comment;
            else
                return null;

        }
        public void Save(Comments comment)
        {
            if (comment.Id == 0)
            {
                _db.Comments.Add(comment);
                _db.SaveChanges();
            }

        }
        public void Update(Comments comment)
        {
            var Comment = _db.Comments.First(p => p.Id == comment.Id);
            if (Comment != null)
            {
                Comment.Comment = comment.Comment;
                Comment.IdPost = comment.IdPost;
                Comment.IdUser = comment.IdUser;
                _db.SaveChanges();
            }
        }
        public List<Comments> PostComments(int IdPost)
        {
            List<Comments> comments = _db.Comments.Where(p => p.IdPost == IdPost).ToList();
            if (comments.Count != 0)
            {
                return comments;
            }
            else return null;
        }
        public List<CommentDto> CommentDtos(int IdPost)
        {
            List<Comments> comments = _db.Comments.Where(p => p.IdPost == IdPost).ToList();
            if (comments.Count != 0)
            {

        
              var dto = new List<CommentDto>();
                foreach(Comments c in comments)
                {
                    var u = _db.Users.FirstOrDefault(p => p.Id == c.IdUser);
                    dto.Add(new CommentDto { Comment=c,UserImage=u.Image,UserName=u.UserName});

                }
                return dto;
            }
            else return null;
        }
    }
}
