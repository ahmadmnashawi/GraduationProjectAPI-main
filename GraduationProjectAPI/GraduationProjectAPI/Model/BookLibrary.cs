namespace GraduationProjectAPI.Model
{
    public class BookLibrary
    {
        public int Id { set; get; }
        public int IdBook { set; get; }
        public virtual Book? Book { set; get; }
        public int IdLibrary { set; get; }
        public virtual Library? Library { set; get; }
        public virtual ICollection<Buybook>? Buybook { set; get; }
        public bool IsDeleted { set; get; }
    }
}
