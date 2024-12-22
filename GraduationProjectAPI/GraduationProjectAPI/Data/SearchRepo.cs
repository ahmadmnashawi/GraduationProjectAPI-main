using GraduationProjectAPI.Dto;
using GraduationProjectAPI.Model;
using GraduationProjectAPI.Infrastructure;
using GraduationProjectAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace GraduationProjectAPI.Data
{
    public class SearchRepo : ISearch
    {
        public readonly GraduationProjectDbContext _db;
        
        public SearchRepo(GraduationProjectDbContext db)
        {
            _db = db;
        }
        public List<SearchDto> Search(string search,int IdUser)
        {
            List<SearchDto> data = new List<SearchDto>();
            List<object> user = _db.Users.Where(p => p.UserName.Contains( search) || p.Name.Contains( search)).ToList<object>();
            List<object> group = _db.Groups.Where(p => p.groupName.Contains(search)).ToList<object>();
            List<object> content = _db.Contents.Where(p => p.typeName.Contains(search)).ToList<object>();
            List<object> library = _db.Libraries.Where(p => p.libraryName.Contains(search)).ToList<object>();
            List<object> complaint = _db.Complaints.Where(p => p.complaint.Contains(search) && p.IdUser==IdUser).ToList<object>();
            List<object> refreance = _db.References.Where(p => p.referenceName.Contains(search)).ToList<object>();
            List<Book> book = _db.Books.Where(p => p.BookName.Contains(search) && p.IsDeleted==false).ToList();
            List<Writer> writer = _db.Writers.Where(p => p.writerName.Contains(search) && p.IsDeleted==false).ToList();
            if(user.Count != 0)
            {
                SearchDto dto = new SearchDto();
                dto.search = user;
                dto.Type = "user";
                data.Add(dto) ;
            }
            if(group.Count != 0)
            {
                SearchDto dto = new SearchDto();
                dto.search = group;
                dto.Type = "group";
                data.Add(dto);
            }
            if(content.Count != 0)
            {
                SearchDto dto = new SearchDto();
                dto.search = content;
                dto.Type = "content";
                data.Add(dto);
            }
            if(library.Count != 0)
            {
                SearchDto dto = new SearchDto();
                dto.search = library;
                dto.Type = "library";
                data.Add(dto);
            }
            if(complaint.Count != 0)
            {
                SearchDto dto = new SearchDto();
                dto.search = complaint;
                dto.Type = "complaint";
                data.Add(dto);
            }
            if(refreance.Count !=0)
            {
                SearchDto dto = new SearchDto();
                dto.search = refreance;
                dto.Type = "refreance";
                data.Add(dto);
            }
            if(book.Count != 0)
            {
                SearchDto dto = new SearchDto();
                List<Library> list = new List<Library>();
                List<object> librarys = new List<object>();
                foreach (Book e in book)
                {
                   List< BookLibrary> l = _db.BookLibraries.Where(p => p.IdBook == e.Id && p.IsDeleted==false).ToList();
                    foreach (BookLibrary x in l)
                    {
                        Library c = _db.Libraries.Where(p => p.Id == x.IdLibrary).FirstOrDefault();
                        if (!list.Contains(c))
                        {
                            librarys.Add(c);
                            list.Add(c);
                        }
                    }
                }
                dto.search = librarys;
                dto.Type = "library";
                data.Add(dto);
            }
            if(writer.Count != 0)
            {
                SearchDto dto = new SearchDto();
                List<Library> list = new List<Library>();
                List<object> librarys = new List<object>();
                foreach (Writer e in writer)
                {
                   List<BookWriter> b = _db.BookWriters.Where(p => p.IdWriter == e.Id && p.IsDeleted==false).ToList();
                    foreach (BookWriter x in b)
                    {
                        List<BookLibrary> c = _db.BookLibraries.Where(p => p.IdBook == x.IdBook && p.IsDeleted == false).ToList();
                        foreach (BookLibrary v in c)
                        {
                            Library l = _db.Libraries.Where(p => p.Id == v.IdLibrary).FirstOrDefault();
                            if (!list.Contains(l))
                            {
                                librarys.Add(l);
                                list.Add(l);
                            }
                        }
                    }
                }
                dto.search = librarys;
                dto.Type = "library";
                data.Add(dto);
            }
            if (data.Count != 0) return data;
            else return null;
        }
        public SearchDto SearchUser(string search)
        {
            List<object> users = _db.Users.Where(p => p.UserName.Contains(search) || p.Name.Contains(search)).ToList<object>();
            if (users.Count != 0)
            {
                SearchDto dto = new SearchDto();
                dto.search = users;
                dto.Type = "user";
                return dto;
            }
            else return null;
        }
        public SearchDto SearchGroup(string search)
        {
            List<object> groups = _db.Groups.Where(p => p.groupName.Contains(search)).ToList<object>();
            if (groups.Count != 0)
            {
                SearchDto dto = new SearchDto();
                dto.search = groups;
                dto.Type = "group";
                return dto;
            }
            else return null;
        }
        public SearchDto SearchContent(string search)
        {
            List<object> content = _db.Contents.Where(p => p.typeName.Contains(search)).ToList<object>();
            if (content.Count != 0)
            {
                SearchDto dto = new SearchDto();
                dto.search = content;
                dto.Type = "content";
                return dto;
            }
            else return null;
        }
        public SearchDto SearchLibrary(string search)
        {
            List<object> library = _db.Libraries.Where(p => p.libraryName.Contains(search)).ToList<object>();
            if (library.Count != 0)
            {
                SearchDto dto = new SearchDto();
                dto.search = library;
                dto.Type = "library";
                return dto;
            }
            else return null;
        }
        public SearchDto SearchComplaint(string search,int IdUser)
        {
            List<object> complaint = _db.Complaints.Where(p => p.complaint.Contains(search) && p.IdUser==IdUser).ToList<object>();
            if (complaint.Count != 0)
            {
                SearchDto dto = new SearchDto();
                dto.search = complaint;
                dto.Type = "complaint";
                return dto;
            }
            else return null;
        }
        public SearchDto SearchReferance(string search)
        {
            List<object> referance = _db.References.Where(p => p.referenceName.Contains(search)).ToList<object>();
            if (referance.Count != 0)
            {
                SearchDto dto = new SearchDto();
                dto.search = referance;
                dto.Type = "referance";
                return dto;
            }
            else return null;
        }
        public SearchDto SearchBook(string search)
        {
            List<object> library = new List<object>();
            List<Library> list = new List<Library>();
            List<Book> book = _db.Books.Where(p => p.BookName.Contains(search) && p.IsDeleted == false).ToList();
            if (book.Count != 0)
            {
                foreach (Book e in book)
                {
                    List<BookLibrary> l = _db.BookLibraries.Where(p => p.IdBook == e.Id && p.IsDeleted == false).ToList();
                    foreach (BookLibrary x in l)
                    {
                        Library c = _db.Libraries.Where(p => p.Id == x.IdLibrary).FirstOrDefault();
                        if (!list.Contains(c))
                        {
                            library.Add(c);
                            list.Add(c);
                        }
                    }
                }
                SearchDto dto = new SearchDto();
                dto.search = library;
                dto.Type = "library";
                return dto;
            }
            else return null;
        }
        public SearchDto SearchWriter(string search)
        {
            List<object> library = new List<object>();
            List<Library> list = new List<Library>();
            List<Writer> bookWriters = _db.Writers.Where(p => p.writerName.Contains(search) && p.IsDeleted == false).ToList();
            if (bookWriters.Count != 0)
            {
                foreach (Writer e in bookWriters)
                {
                    List<BookWriter> b = _db.BookWriters.Where(p => p.IdWriter == e.Id && p.IsDeleted == false).ToList();
                    foreach (BookWriter x in b)
                    {
                        List<BookLibrary> c = _db.BookLibraries.Where(p => p.IdBook == x.IdBook && p.IsDeleted == false).ToList();
                        foreach (BookLibrary v in c)
                        {
                            Library l = _db.Libraries.Where(p => p.Id == v.IdLibrary).FirstOrDefault();
                            if (!list.Contains(l))
                            {
                                library.Add(l);
                                list.Add(l);
                            }
                        }
                    }
                }
                SearchDto dto = new SearchDto();
                dto.search = library;
                dto.Type = "library";
                return dto;
            }
            else return null;
        }
    }
}
