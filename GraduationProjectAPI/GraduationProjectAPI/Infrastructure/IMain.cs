using GraduationProjectAPI.Dto;
using GraduationProjectAPI.Model;
namespace GraduationProjectAPI.Infrastructure
{
    public interface IMain
    {
      public List<PostDto> Posts(int id);
      public List<PostDto> PostContent(int IdUser, int IdContent);
    }
}
