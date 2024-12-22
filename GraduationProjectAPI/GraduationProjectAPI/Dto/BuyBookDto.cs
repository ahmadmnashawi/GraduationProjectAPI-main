using GraduationProjectAPI.Model;
namespace GraduationProjectAPI.Dto
{
    public class BuyBookDto
    {
        public User user { set; get; }
        public List<Buybook> userBooks { set; get; }
    }
}
