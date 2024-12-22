using GraduationProjectAPI.Model;
namespace GraduationProjectAPI.Infrastructure
{
    public interface IContent
    {
        public Content GetContent(int id);
        public IQueryable<Content> GetContents { get; }
        public bool Save(Content content);
        public void Update(Content content);
        public void Delete(Content content);
    }
}
