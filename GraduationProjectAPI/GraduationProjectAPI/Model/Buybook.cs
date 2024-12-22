namespace GraduationProjectAPI.Model
{
    public class Buybook
    {
        // book-user
        public int Id { set; get; }
        public double Price { set; get; }
        public int Count { set; get; }
        public string? Address { set; get; }
        public int IdUser { set; get; }
        public virtual User? User { set; get; }
        public int IdBookLibrary { set; get; }
        public virtual BookLibrary? BookLibrary { set; get; }
    }
}
