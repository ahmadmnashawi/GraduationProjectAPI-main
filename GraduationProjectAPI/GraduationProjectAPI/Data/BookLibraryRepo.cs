using GraduationProjectAPI.Infrastructure;
using GraduationProjectAPI.Model;
namespace GraduationProjectAPI.Data
{
    public class BookLibraryRepo:IBookLibrarycs
    {
        private readonly GraduationProjectDbContext _db;
        public BookLibraryRepo(GraduationProjectDbContext db)
        {
            _db = db;
        }
        public IQueryable<BookLibrary> GetBookLibraries => _db.BookLibraries.Where(p => p.IsDeleted==false);
        

        public void Delete(BookLibrary bookLibrary)
        {
            var BookLibrary = _db.BookLibraries.FirstOrDefault(p => p.Id == bookLibrary.Id && p.IsDeleted==false);
            if (BookLibrary != null)
            {
                BookLibrary.IsDeleted = true;
               // _db.BookLibraries.Remove(bookLibrary);
                _db.SaveChanges();
            }


        }
        public BookLibrary GetBookLibrary(int id)
        {
            var bookLibrary = _db.BookLibraries.FirstOrDefault(p => p.Id == id && p.IsDeleted==false);
            if (bookLibrary != null)
                return bookLibrary;
            else
                return null;

        }
        public bool Save(BookLibrary bookLibrary)
        {
            if (bookLibrary.Id == 0)
            {
                if (IsExisting(bookLibrary) != true)
                {
                    _db.BookLibraries.Add(bookLibrary);
                    _db.SaveChanges();
                    return true;
                }
            }
            return false;
        }
        public void Update(BookLibrary bookLibrary)
        {
            var booklibrary = _db.BookLibraries.FirstOrDefault(p => p.Id == bookLibrary.Id && p.IsDeleted==false);
            if (booklibrary != null)
            {
                booklibrary.IdBook = bookLibrary.IdBook;
                booklibrary.IdLibrary = bookLibrary.IdLibrary;
                booklibrary.IsDeleted = bookLibrary.IsDeleted;
                _db.SaveChanges();
            }
        }
        public bool IsExisting(BookLibrary bookLibrary)
        {
            var book = _db.BookLibraries.FirstOrDefault(p => p.IdBook == bookLibrary.IdBook && p.IdLibrary==bookLibrary.IdLibrary &&p.IsDeleted==false);
            if(book != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int GetIdLibraryBook(int IdBook, int IdLibrary)
        {
            var book = _db.Books.FirstOrDefault(p => p.Id == IdBook && p.IsDeleted==false);
            var library = _db.Libraries.FirstOrDefault(p => p.Id == IdLibrary);
            BookLibrary bl = new BookLibrary();
            if (book != null && library != null)
            {
                 bl = _db.BookLibraries.FirstOrDefault(p => p.IdBook == IdBook && p.IdLibrary == IdLibrary && p.IsDeleted==false);
            }
            if (bl != null)
            {
                return bl.Id;
            }
            else
            {
                return 0;
            }
        }
    }
}
