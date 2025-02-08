using GraduationProjectAPI.Model;
namespace GraduationProjectAPI.Infrastructure
{
    public interface IBookWriter
    {
        public BookWriter GetBookWriter(int id);
        public List<BookWriter> GetBookAllWriter(int id);
        public IQueryable<BookWriter> GetBookWriters { get; }
        public bool Save(BookWriter bookWriter);
        public void Update(int idBook, int IdWriter, bool toDelete);
        public void Delete(BookWriter BookWriter);
    }
}
