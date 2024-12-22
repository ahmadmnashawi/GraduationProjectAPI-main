using GraduationProjectAPI.Model;
using GraduationProjectAPI.Infrastructure;
namespace GraduationProjectAPI.Data
{
    public class BookWriterRepo : IBookWriter
    {
        private readonly GraduationProjectDbContext _db;
        public BookWriterRepo(GraduationProjectDbContext db)
        {
            _db = db;
        }
        public IQueryable<BookWriter> GetBookWriters => _db.BookWriters.Where(p=>p.IsDeleted==false);

        public void Delete(BookWriter BookWriter)
        {
            var bookWriter = _db.BookWriters.FirstOrDefault(p => p.Id == BookWriter.Id && p.IsDeleted==false);
            if (bookWriter != null)
            {
                bookWriter.IsDeleted = true;
               // _db.BookWriters.Remove(bookWriter);
                _db.SaveChanges();
            }


        }
        public BookWriter GetBookWriter(int id)
        {
            var bookWriter = _db.BookWriters.FirstOrDefault(p => p.Id == id && p.IsDeleted==false);
            if (bookWriter != null)
                return bookWriter;
            else
                return null;

        }
        public bool Save(BookWriter bookWriter)
        {
            if (bookWriter.Id == 0)
            {
                if (!IsExisting(bookWriter))
                {
                    _db.BookWriters.Add(bookWriter);
                    _db.SaveChanges();
                    return true;
                }
            }
            return false;
        }
        public void Update(BookWriter bookWriter)
        {
            var BookWriter = _db.BookWriters.FirstOrDefault(p => p.Id == bookWriter.Id && p.IsDeleted==false);
            if (BookWriter != null)
            {
                BookWriter.IdBook = bookWriter.IdBook;
                BookWriter.IdWriter = bookWriter.IdWriter;
                BookWriter.IsDeleted = bookWriter.IsDeleted;
                _db.SaveChanges();
            }
        }
        public bool IsExisting(BookWriter BookWriter)
        {
            var data = _db.BookWriters.Any(p=>p.IdBook==BookWriter.IdBook && p.IdWriter==BookWriter.IdWriter);
            if (data != true)
            {
                return false;
            }
            else return true;
        }
    }
}
