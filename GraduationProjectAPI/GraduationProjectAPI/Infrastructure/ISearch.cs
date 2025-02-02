using GraduationProjectAPI.Model;
using GraduationProjectAPI.Dto;
namespace GraduationProjectAPI.Infrastructure
{
    public interface ISearch
    {
        public List<SearchDto> Search(string search,int IdUser);
        public SearchDto SearchUser(string search, int IdUser);
        public SearchDto SearchGroup(string search, int IdUser);
        public SearchDto SearchContent(string search, int IdUser);
        public SearchDto SearchLibrary(string search, int IdUser);
        public SearchDto SearchComplaint(string search,int IdUser);
        public SearchDto SearchReferance(string search, int IdUser);
        public SearchDto SearchBook(string search, int IdUser);
        public SearchDto SearchWriter(string search, int IdUser);
    }
}
