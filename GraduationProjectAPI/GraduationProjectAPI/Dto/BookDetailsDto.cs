using GraduationProjectAPI.Model;
namespace GraduationProjectAPI.Dto
{
    public class BookDetailsDto
    {
        public  Book Book { set; get; }
        public string Type { set; get; }
        public List<string> Writers { set; get; }
    }
}
