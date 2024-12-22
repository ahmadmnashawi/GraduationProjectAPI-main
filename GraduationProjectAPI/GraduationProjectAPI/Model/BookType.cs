namespace GraduationProjectAPI.Model
{
    public class BookType
    {
        public int Id { set; get; }
        public string bookType { set; get; }
        public bool IsDeleted { set; get; }
        public virtual ICollection<Book>? Book { set; get; }
    }
}
