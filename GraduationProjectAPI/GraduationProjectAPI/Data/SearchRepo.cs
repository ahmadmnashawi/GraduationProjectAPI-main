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
            var user = _db.Users.Where(p => p.UserName.Contains( search) || p.Name.Contains( search)).ToList();
            var group = _db.Groups.Where(p => p.groupName.Contains(search)).Include(t=>t.Content).ToList();
            var content = _db.Contents.Where(p => p.typeName.Contains(search)).ToList();
            var library = _db.Libraries.Where(p => p.libraryName.Contains(search)).ToList();
            var complaint = _db.Complaints.Where(p => p.complaint.Contains(search) && p.IdUser==IdUser).ToList();
            var refreance = _db.References.Where(p => p.referenceName.Contains(search)).ToList();
            var book = _db.Books.Where(p => p.BookName.Contains(search) && p.IsDeleted==false).ToList();
            var writer = _db.Writers.Where(p => p.writerName.Contains(search) && p.IsDeleted==false).ToList();
            if(user.Count != 0)
            {
                SearchDto dto = new SearchDto();
                dto.search = new List<SubSearchDto>();
                foreach (var item in user)
                {
                    var searchData = (object)item;
                    var followd = _db.Follows.Where(t => t.followId == IdUser && t.followedId == item.Id).FirstOrDefault();
                    if (followd != null)
                    {
                        dto.search.Add(new SubSearchDto { SearchData = searchData, IsFollowed = true });
                    }
                    else
                    {
                        dto.search.Add(new SubSearchDto { SearchData = searchData, IsFollowed = false });
                    }

                }

                dto.Type = "user";
                data.Add(dto) ;
            }
            if(group.Count != 0)
            {
                SearchDto dto = new SearchDto();
                dto.search = new List<SubSearchDto>();
                foreach (var item in group)
                {
                    var followd = _db.UserGroups.Where(t => t.IdUser == IdUser && t.IdGroup == item.Id).FirstOrDefault();
                    if (followd != null)
                    {
                        dto.search.Add(new SubSearchDto { SearchData = item ,IsFollowed=true});
                    }
                    else
                    {
                        dto.search.Add(new SubSearchDto { SearchData = item, IsFollowed = false });
                    }

                }
                dto.Type = "group";
                data.Add(dto);
            }
            if(content.Count != 0)
            {
                SearchDto dto = new SearchDto();
                dto.search = new List<SubSearchDto>();
                foreach (var item in content)
                {
                    dto.search.Add(new SubSearchDto { SearchData = item });

                }
                dto.Type = "content";
                data.Add(dto);
            }
            if(library.Count != 0)
            {
                SearchDto dto = new SearchDto();
                dto.search = new List<SubSearchDto>();
                foreach (var item in library)
                {
                    dto.search.Add(new SubSearchDto { SearchData = item });

                }
                dto.Type = "library";
                data.Add(dto);
            }
            if(complaint.Count != 0)
            {
                SearchDto dto = new SearchDto();
                dto.search = new List<SubSearchDto>();
                foreach (var item in complaint)
                {
                    dto.search.Add(new SubSearchDto { SearchData = item });

                }
                dto.Type = "complaint";
                data.Add(dto);
            }
            if(refreance.Count !=0)
            {
                SearchDto dto = new SearchDto();
                dto.search = new List<SubSearchDto>();
                foreach (var item in refreance)
                {
                    dto.search.Add(new SubSearchDto { SearchData = item });

                }
                dto.Type = "refreance";
                data.Add(dto);
            }
            if(book.Count != 0)
            {
                SearchDto dto = new SearchDto();
                dto.search = new List<SubSearchDto>();
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
                            dto.search.Add(new SubSearchDto { SearchData = c });
                            list.Add(c);
                        }
                    }
                }
                dto.Type = "library";
                data.Add(dto);
            }
            if(writer.Count != 0)
            {
                SearchDto dto = new SearchDto();
                dto.search = new List<SubSearchDto>();
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
                                dto.search.Add(new SubSearchDto { SearchData = l });
                   
                                list.Add(l);
                            }
                        }
                    }
                }
                dto.Type = "library";
                data.Add(dto);
            }
            if (data.Count != 0) return data;
            else return null;
        }
        public SearchDto SearchUser(string search, int IdUser)
        {
           var users = _db.Users.Where(p => p.UserName.Contains(search) || p.Name.Contains(search)).ToList();
            if (users.Count != 0)
            {
                SearchDto dto = new SearchDto();
                dto.search = new List<SubSearchDto>();
                foreach (var item in users)
                {
                    var followd = _db.Follows.Where(t => t.followId == IdUser && t.followedId == item.Id).FirstOrDefault();
                    if (followd != null)
                    {
                        dto.search.Add(new SubSearchDto { SearchData = item, IsFollowed = true });
                    }
                    else
                    {
                        dto.search.Add(new SubSearchDto { SearchData = item, IsFollowed = false });
                    }

                }
                dto.Type = "user";
                return dto;
            }
            else return null;
        }
        public SearchDto SearchGroup(string search, int IdUser)
        {
            var groups = _db.Groups.Where(p => p.groupName.Contains(search)).Include(t => t.Content).ToList();
            if (groups.Count != 0)
            {
                SearchDto dto = new SearchDto();
                dto.search = new List<SubSearchDto>();
                foreach (var item in groups)
                {
                    var followd = _db.UserGroups.Where(t => t.IdUser == IdUser && t.IdGroup == item.Id).FirstOrDefault();
                    if (followd != null)
                    {
                        dto.search.Add(new SubSearchDto { SearchData = item, IsFollowed = true });
                    }
                    else
                    {
                        dto.search.Add(new SubSearchDto { SearchData = item, IsFollowed = false });
                    }

                }
                dto.Type = "group";
                return dto;
            }
            else return null;
        }
        public SearchDto SearchContent(string search, int IdUser)
        {
            List<object> content = _db.Contents.Where(p => p.typeName.Contains(search)).ToList<object>();
            if (content.Count != 0)
            {
                SearchDto dto = new SearchDto();
                dto.search = new List<SubSearchDto>();
                foreach (var item in content)
                {
                    dto.search.Add(new SubSearchDto { SearchData = item });

                }
                dto.Type = "content";
                return dto;
            }
            else return null;
        }
        public SearchDto SearchLibrary(string search, int IdUser)
        {
            List<object> library = _db.Libraries.Where(p => p.libraryName.Contains(search)).ToList<object>();
            if (library.Count != 0)
            {
                SearchDto dto = new SearchDto();
                dto.search = new List<SubSearchDto>();
                foreach (var item in library)
                {
                    dto.search.Add(new SubSearchDto { SearchData = item });

                }
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
                dto.search = new List<SubSearchDto>();
                foreach (var item in complaint)
                {
                    dto.search.Add(new SubSearchDto { SearchData = item });

                }
                dto.Type = "complaint";
                return dto;
            }
            else return null;
        }
        public SearchDto SearchReferance(string search, int IdUser)
        {
            var referance = _db.References.Where(p => p.referenceName.Contains(search)).ToList();
            if (referance.Count != 0)
            {
                SearchDto dto = new SearchDto();
                dto.search = new List<SubSearchDto>();
                foreach (var item in referance)
                {
                    dto.search.Add(new SubSearchDto { SearchData = item });

                }
                dto.Type = "referance";
                return dto;
            }
            else return null;
        }
        public SearchDto SearchBook(string search, int IdUser)
        {
   
            List<Book> book = _db.Books.Where(p => p.BookName.Contains(search) && p.IsDeleted == false).ToList();
            if (book.Count != 0)
            {
                SearchDto dto = new SearchDto();
                dto.search = new List<SubSearchDto>();
                List<Library> list = new List<Library>();
                List<object> librarys = new List<object>();
                foreach (Book e in book)
                {
                    List<BookLibrary> l = _db.BookLibraries.Where(p => p.IdBook == e.Id && p.IsDeleted == false).ToList();
                    foreach (BookLibrary x in l)
                    {
                        Library c = _db.Libraries.Where(p => p.Id == x.IdLibrary).FirstOrDefault();
                        if (!list.Contains(c))
                        {
                            dto.search.Add(new SubSearchDto { SearchData = c });
                            list.Add(c);
                        }
                    }
                }
                dto.Type = "library";
                return dto;
            }
            else return null;
        }
        public SearchDto SearchWriter(string search, int IdUser)
        {
 
            List<Writer> bookWriters = _db.Writers.Where(p => p.writerName.Contains(search) && p.IsDeleted == false).ToList();
            if (bookWriters.Count != 0)
            {
                SearchDto dto = new SearchDto();
                dto.search = new List<SubSearchDto>();
                List<Library> list = new List<Library>();
                List<object> librarys = new List<object>();
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
                                dto.search.Add(new SubSearchDto { SearchData = l });

                                list.Add(l);
                            }
                        }
                    }
                }
                dto.Type = "library";
                return dto;
            }
            else return null;
        }
    }
}
