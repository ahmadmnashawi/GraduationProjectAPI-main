using GraduationProjectAPI.Model;
using GraduationProjectAPI.Dto;
namespace GraduationProjectAPI.Infrastructure
{
    public interface IBook
    {
        public Book GetBook(int id);
        public IQueryable<Book> GetBooks { get; }
        public bool Save(Book book);
        public void Update(Book book);
        public void Delete(Book book);
        public BookDetailsDto BookDetails(int IdBook);
        public int GetBookId(string name);
        public List<BookWriter> GetBookWriters(int IdBook);
    }
}
