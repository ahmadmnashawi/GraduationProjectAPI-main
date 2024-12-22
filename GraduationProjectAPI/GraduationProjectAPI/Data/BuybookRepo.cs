using GraduationProjectAPI.Model;
using GraduationProjectAPI.Infrastructure;
using GraduationProjectAPI.Dto;
using Microsoft.EntityFrameworkCore;

namespace GraduationProjectAPI.Data
{
    public class BuybookRepo :IBuybook
    {
        private readonly GraduationProjectDbContext _db;
        public BuybookRepo(GraduationProjectDbContext db)
        {
            _db = db;
        }
        public IQueryable<Buybook> GetBuybooks => _db.Buybooks;

        public void Delete(Buybook Buybook)
        {
            var buyBook = _db.Buybooks.FirstOrDefault(p => p.Id == Buybook.Id);
            if (buyBook != null)
            {
                _db.Buybooks.Remove(buyBook);
                _db.SaveChanges();
            }


        }
        public Buybook GetBuybook(int id)
        {
            var buyBook = _db.Buybooks.FirstOrDefault(p => p.Id == id);
            if (buyBook != null)
                return buyBook;
            else
                return null;

        }
        public void Save(Buybook buyBook)
        {
            if (buyBook.Id == 0)
            {
                _db.Buybooks.Add(buyBook);
                _db.SaveChanges();
            }

        }
        public void Update(Buybook buyBook)
        {
            var BuyBook = _db.Buybooks.FirstOrDefault(p => p.Id == buyBook.Id);
            if (BuyBook != null)
            {
                BuyBook.Address = buyBook.Address;
                BuyBook.IdBookLibrary = buyBook.IdBookLibrary;
                BuyBook.IdUser = buyBook.IdUser;
                BuyBook.Price = buyBook.Price;
                BuyBook.Count = buyBook.Count;
                _db.SaveChanges();
            }
        }
        public List<BuyBookDto> GetAllBuys(int IdLibrary)
        {
            var library = _db.Libraries.FirstOrDefault(p => p.Id == IdLibrary);
            List<Buybook> buybooks=new List<Buybook>();
            List<BuyBookDto> dto = new List<BuyBookDto>();
           List< int >idUser =new List<int>(0);
            if (library != null)
            {
                List<BookLibrary> bookLibraries = _db.BookLibraries.Where(p => p.IdLibrary == IdLibrary && p.IsDeleted == false).ToList();
                foreach(BookLibrary e in bookLibraries)
                {
                   List<Buybook>  b = _db.Buybooks.Where(p => p.IdBookLibrary == e.Id).ToList();
                    if(b.Count != 0)
                    {
                        buybooks.AddRange(b);
                    }
                }
                if(buybooks.Count != 0)
                foreach(Buybook e in buybooks)
                {
                    List<Buybook> usersbuy = _db.Buybooks.Where(p => p.IdUser == e.IdUser && !idUser.Contains(p.IdUser)).ToList();
                        if (usersbuy.Count != 0)
                        {
                            BuyBookDto buyBookDto = new BuyBookDto();
                            buyBookDto.user = _db.Users.FirstOrDefault(p => p.Id == e.IdUser);
                            buyBookDto.userBooks = usersbuy;
                            if( !dto.Contains(buyBookDto))
                            dto.Add(buyBookDto);
                             idUser.Add(buyBookDto.user.Id);
                        }
                }
                if(dto.Count != 0)
                {
                    return dto;
                }
                return null;
            }
            else
            {
                return null;
            }
        }
        public List<BuyBookDetailsDto> GetBookDetails(int IdLibrary,int IdUser)
        {
            List<BuyBookDetailsDto> buybooks = new List<BuyBookDetailsDto>();
            var user = _db.Users.FirstOrDefault(p => p.Id == IdUser);
            var library = _db.Libraries.FirstOrDefault(p => p.Id == IdLibrary);
            if(user != null && library != null)
            {
                List<BookLibrary> bookLibraries = _db.BookLibraries.Where(p => p.IdLibrary == IdLibrary && p.IsDeleted==false).ToList();
                foreach(BookLibrary e in bookLibraries)
                {
                    List<Buybook> b = _db.Buybooks.Where(p => p.IdBookLibrary == e.Id && p.IdUser == IdUser).ToList();
                    Book book = _db.Books.FirstOrDefault(p => p.Id == e.IdBook && p.IsDeleted==false);
                    if(b.Count != 0)
                    {
                        BuyBookDetailsDto buyBookDetailsDto = new BuyBookDetailsDto();
                        buyBookDetailsDto.book = book;
                        buyBookDetailsDto.buybooks = b;
                        buybooks.Add(buyBookDetailsDto);
                    }
                }
                if (buybooks.Count != 0)
                {
                    return buybooks;
                }
                else return null;
            }
            else
            {
                return null;
            }
        }
        public List<BuyBookUserDto> GetAllUserBuys(int IdUser)
        {
            var user = _db.Users.FirstOrDefault(p => p.Id == IdUser);
            List<BookLibrary> bookLibraries = new List<BookLibrary>();
            List<BuyBookUserDto> books = new List<BuyBookUserDto>();
            List<Library> libraries = new List<Library>();
      
            if (user != null)
            {
                List<Buybook> buybooks = _db.Buybooks.Where(p => p.IdUser == IdUser).ToList();
                foreach (Buybook e in buybooks)
                {
                    List<BookLibrary> b = _db.BookLibraries.Where(p => p.Id == e.IdBookLibrary && p.IsDeleted==false).ToList();
                    if(b.Count != 0)
                    {
                        bookLibraries.AddRange(b);
                    }
                }
                if (bookLibraries.Count != 0)
                {
                    foreach (BookLibrary e in bookLibraries)
                    {
                        BuyBookUserDto dto = new BuyBookUserDto();
                        dto.library = _db.Libraries.FirstOrDefault(p => p.Id == e.IdLibrary);
                        dto.book = _db.Books.FirstOrDefault(p => p.Id == e.IdBook && p.IsDeleted==false);
                        dto.userBuyBook = _db.Buybooks.Where(p => p.IdBookLibrary == e.Id).ToList();
                        if(!libraries.Contains(dto.library))
                        {
                            books.Add(dto);
                        }
                        libraries.Add(dto.library);
                    }
                }
                if (books.Count != 0)
                {
                    return books;
                }
                else return null;
            }
            else
            {
                return null;
            }
        }
    }
}
