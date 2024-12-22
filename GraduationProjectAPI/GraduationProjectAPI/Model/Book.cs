namespace GraduationProjectAPI.Model
{
    public class Book
    {
        public int Id { set; get; }
        public string BookName { set; get; }
        public int BookPrice { set; get; }
        public bool IsDeleted { set; get; }
        public byte[]? bookImage { set; get; }
        public virtual ICollection<BookLibrary>? BookLibrary { set; get; }
        public virtual ICollection<BookWriter>? BookWriter { set; get; }
        public int IdBookType { set; get; }
        public virtual BookType? BookType { set; get; }
    }
}
