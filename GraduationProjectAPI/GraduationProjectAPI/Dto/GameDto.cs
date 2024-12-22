using GraduationProjectAPI.Model;
namespace GraduationProjectAPI.Dto
{
    public class GameDto
    {
        public Game Game { set; get; }
        public List<GameUser> GameUser { set; get; }
    }
}
