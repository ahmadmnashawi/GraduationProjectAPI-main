using GraduationProjectAPI.Model;
namespace GraduationProjectAPI.Infrastructure
{
    public interface IBookType
    {
        public BookType GetBookType(int id);
        public IQueryable<BookType> GetBookTypes { get; }
        public void Save(BookType bookType);
        public void Update(BookType bookType);
        public void Delete(int id);
    }
}
