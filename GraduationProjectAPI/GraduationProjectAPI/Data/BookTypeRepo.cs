using GraduationProjectAPI.Infrastructure;
using GraduationProjectAPI.Model;
namespace GraduationProjectAPI.Data
{
    public class BookTypeRepo : IBookType
    {
        private readonly GraduationProjectDbContext _db;
        public BookTypeRepo(GraduationProjectDbContext db)
        {
            _db = db;
        }
        public IQueryable<BookType> GetBookTypes => _db.BookTypes.Where(p=>p.IsDeleted==false);

        public void Delete(int id)
        {
            var bookType= _db.BookTypes.FirstOrDefault(p => p.Id == id && p.IsDeleted==false );
            if (bookType != null)
            {
                bookType.IsDeleted = true;
                List<Book> books = _db.Books.Where(p => p.IdBookType == id && p.IsDeleted == false).ToList();
                foreach(Book e in books)
                {
                    DeleteBookLibraries(e.Id);
                    DeleteBookWriter(e.Id);
                }
                // _db.BookTypes.Remove(bookType);
                _db.SaveChanges();
            }


        }
        public void DeleteBookWriter(int idBook)
        {
            var bookWriters = _db.BookWriters.Where(p => p.IdBook == idBook && p.IsDeleted == false);
            if(bookWriters != null)
            {
                foreach(BookWriter e in bookWriters)
                {
                    e.IsDeleted = true;
                }
            }
        }
        public void DeleteBookLibraries(int idBook)
        {
            var bookLibraries = _db.BookLibraries.Where(p => p.IdBook == idBook && p.IsDeleted == false);
            if (bookLibraries != null)
            {
                foreach (BookLibrary e in bookLibraries)
                {
                    e.IsDeleted = true;
                }
            }
        }
        public BookType GetBookType(int id)
        {
            var bookType = _db.BookTypes.FirstOrDefault(p => p.Id == id && p.IsDeleted==false);
            if (bookType != null)
                return bookType;
            else
                return null;

        }
        public void Save(BookType bookType)
        {
            if (bookType.Id == 0)
            {
                if ( !IsExisting(bookType))
                {
                    _db.BookTypes.Add(bookType);
                    _db.SaveChanges();
                }
            }

        }
        public void Update(BookType bookType)
        {
            var BookType = _db.BookTypes.FirstOrDefault(p => p.Id == bookType.Id && p.IsDeleted == false);
            if (BookType != null)
            {
                BookType.bookType = bookType.bookType;
                BookType.IsDeleted = bookType.IsDeleted;
                _db.SaveChanges();
            }
        }
        public bool IsExisting(BookType b)
        {
            var data = _db.BookTypes.Any(p => p.bookType.Equals(b.bookType));
            // var data = _db.Contents.Where(u => string.Equals(u.typeName, content.typeName, StringComparison.CurrentCultureIgnoreCase));
            if (data == false)
            {
                return false;
            }
            else return true;
        }
    }
}
