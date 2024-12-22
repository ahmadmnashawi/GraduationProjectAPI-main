using GraduationProjectAPI.Model;
namespace GraduationProjectAPI.Dto
{
    public class BuyBookDetailsDto
    {
        public Book book { set; get; }
        public List<Buybook> buybooks { set; get; }
    }
}
