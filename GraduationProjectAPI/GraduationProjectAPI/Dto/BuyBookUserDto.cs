using GraduationProjectAPI.Model;
namespace GraduationProjectAPI.Dto
{
    public class BuyBookUserDto
    {
        public Library library { set; get; }
        public Book book { set; get; }
        public List<Buybook> userBuyBook { set;get; }
    }
}
