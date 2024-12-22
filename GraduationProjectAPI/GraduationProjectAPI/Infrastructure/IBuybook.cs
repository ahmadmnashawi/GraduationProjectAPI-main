using GraduationProjectAPI.Model;
using GraduationProjectAPI.Dto;
namespace GraduationProjectAPI.Infrastructure
{
    public interface IBuybook
    {
        public Buybook GetBuybook(int id);
        public IQueryable<Buybook> GetBuybooks { get; }
        public void Save(Buybook buybook);
        public void Update(Buybook buybook);
        public void Delete(Buybook buybook);
        public List<BuyBookDto> GetAllBuys(int IdLibrary);
        public List<BuyBookDetailsDto> GetBookDetails(int IdLibrary, int IdUser);
        public List<BuyBookUserDto> GetAllUserBuys(int IdUser);
    }
}
