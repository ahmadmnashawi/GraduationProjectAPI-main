using GraduationProjectAPI.Dto;
using GraduationProjectAPI.Infrastructure;
using GraduationProjectAPI.Model;
namespace GraduationProjectAPI.Data
{
    public class BookRepo:IBook
    {
        private readonly GraduationProjectDbContext _db;
        public BookRepo(GraduationProjectDbContext db)
        {
            _db = db;
        }
        public IQueryable<Book> GetBooks => _db.Books.Where(p=>p.IsDeleted==false);

        public void Delete(Book Book)
        {
            var book = _db.Books.FirstOrDefault(p => p.Id == Book.Id && p.IsDeleted==false);
            if (book != null)
            {
                book.IsDeleted = true;
                //_db.Books.Remove(book);
                _db.SaveChanges();
            }


        }
        public Book GetBook(int id)
        {
            var book = _db.Books.FirstOrDefault(p => p.Id == id && p.IsDeleted==false);
            if (book != null)
                return book;
            else
                return null;

        }
        public bool Save(Book book)
        {
            if (book.Id == 0)
            {
                if (!IsExisting(book))
                {
                    _db.Books.Add(book);
                    _db.SaveChanges();
                    return true;
                }
            }
            return false;
        }
        public void Update(Book book)
        {
            var Book = _db.Books.FirstOrDefault(p => p.Id == book.Id && p.IsDeleted==false);
            if (Book != null)
            {
                Book.bookImage = book.bookImage;
                Book.BookName = book.BookName;
                Book.BookPrice = book.BookPrice;
                Book.IdBookType = book.IdBookType;
                Book.IsDeleted = book.IsDeleted;
                _db.SaveChanges();
            }
        }
        public bool IsExisting(Book b)
        {
            var data = _db.Books.Any(p => p.BookName.Equals(b.BookName));
            // var data = _db.Contents.Where(u => string.Equals(u.typeName, content.typeName, StringComparison.CurrentCultureIgnoreCase));
            if (data == false)
            {
                return false;
            }
            else return true;
        }
        public BookDetailsDto BookDetails(int IdBook)
        {
            List<string> Writers = new List<string>();
            BookDetailsDto dto = new BookDetailsDto();
            var book = _db.Books.FirstOrDefault(p => p.Id == IdBook && p.IsDeleted==false);
            if(book != null)
            {
                List<BookWriter> bookWriters = _db.BookWriters.Where(p => p.IdBook == IdBook && p.IsDeleted == false).ToList();
                foreach(BookWriter e in bookWriters)
                {
                    Writer w = _db.Writers.FirstOrDefault(p => p.Id == e.IdWriter && p.IsDeleted == false);
                    Writers.Add(w.writerName);
                }
                BookType bookType = _db.BookTypes.FirstOrDefault(p => p.Id == book.IdBookType && p.IsDeleted == false);
                dto.Book = book;
                dto.Writers = Writers;
                dto.Type = bookType.bookType;
                return dto;
            }
            else
            {
                return null;
            }
        }
        public int GetBookId(string name)
        {
            var book = _db.Books.FirstOrDefault(p => p.BookName == name && p.IsDeleted == false);
            if(book != null)
            {
                return book.Id;
            }
            else
            {
                return 0;
            }
        }
        public List<BookWriter> GetBookWriters(int IdBook)
        {
            var book = _db.Books.FirstOrDefault(p => p.Id == IdBook && p.IsDeleted == false);
            if(book != null)
            {
                List<BookWriter> bookWriters = _db.BookWriters.Where(p => p.IdBook == IdBook && p.IsDeleted == false).ToList();
                if(bookWriters.Count !=0)
                {
                    return bookWriters;
                }
                return null;
            }
            else
            {
                return null;
            }
        }
    }
}
