namespace GraduationProjectAPI.Model
{
    public class BookWriter
    {
        public int Id { set; get; }
        public int IdBook { set; get; }
        public virtual Book? Book { set; get; }
        public int IdWriter { set; get; }
        public virtual Writer? Writer { set; get; }
        public bool IsDeleted { set; get; }
    }
}
