using GraduationProjectAPI.Model;
using GraduationProjectAPI.Dto;
namespace GraduationProjectAPI.Infrastructure
{
    public interface IComments
    {
        public Comments GetComment(int id);
        public IQueryable<Comments> GetComments { get; }
        public void Save(Comments comment);
        public void Update(Comments comment);
        public void Delete(Comments comment);
        public List<Comments> PostComments(int IdPost);
        public List<CommentDto> commentDtos(int IdPost);
    }
}
