using GraduationProjectAPI.Model;
using GraduationProjectAPI.Infrastructure;
using Microsoft.EntityFrameworkCore;

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

        public List<BookWriter> GetBookAllWriter(int id)
        {
            var bookWriter = _db.BookWriters.Include(t => t.Writer).Where(p => p.IdBook == id && p.IsDeleted == false).ToList();
 
            if (bookWriter != null)
            {
                foreach (var item in bookWriter)
                {
                    item.Writer = _db.Writers.FirstOrDefault(t => t.Id == item.IdWriter);
                }
                return bookWriter;
            }  else
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
        public void  Update(int idBook, int IdWriter,bool toDelete)

        {
            if (toDelete)
            {
                var BookWriter = _db.BookWriters.FirstOrDefault(p => p.IdBook == idBook && p.IdWriter == IdWriter);
                if (BookWriter != null)
                {
                    _db.BookWriters.Remove(BookWriter);
                    _db.SaveChanges();
                }
            }
            else
            {
                Save(new BookWriter { Id = 0, IdBook = idBook, IdWriter = IdWriter, IsDeleted = false });
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
