namespace GraduationProjectAPI.Model
{
    public class Writer
    {
        public int Id { set; get; }
        public string writerName { set; get; }
        public bool IsDeleted { set; get; }
        public virtual ICollection<BookWriter>? BookWriter { set; get; }
    }
}
