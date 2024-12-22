using GraduationProjectAPI.Model;
using GraduationProjectAPI.Dto;
namespace GraduationProjectAPI.Infrastructure
{
    public interface ISearch
    {
        public List<SearchDto> Search(string search,int IdUser);
        public SearchDto SearchUser(string search);
        public SearchDto SearchGroup(string search);
        public SearchDto SearchContent(string search);
        public SearchDto SearchLibrary(string search);
        public SearchDto SearchComplaint(string search,int IdUser);
        public SearchDto SearchReferance(string search);
        public SearchDto SearchBook(string search);
        public SearchDto SearchWriter(string search);
    }
}
